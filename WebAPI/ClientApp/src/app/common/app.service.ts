/*
* Do not touch this file if you don't have to.
* The change in here may effect the whole project code.
* If you need to change it, make sure you eventually test the whole app, and passed all the test
*/

import {
  HttpClient,
  HttpRequest,
  HttpResponse,
  HttpInterceptor,
  HttpHandler,
  HttpEvent,
  HttpParams
} from '@angular/common/http';
import { Injectable, TemplateRef } from '@angular/core';
import { Observable, BehaviorSubject, of, Subject } from 'rxjs';
import { map, catchError, switchMap, tap, debounceTime, delay, mergeMap } from 'rxjs/operators';
import { AppUtil, parseResponse } from './app.util';
import { LoginViewModel } from './models/user-model';
import { SortColumn, SortDirection } from './sortable.directive'
import { AuthService } from './auth.service';


interface SearchResult<T> {
  items: T[];
  pageIndex: number;
  totalPages: number;
  totalCount: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
}

export interface QueryState<T> {
  showDeleted?: boolean;
  page: number;
  pageSize: number;
  parentId: number;
  searchTerm: string;
  sortColumn: SortColumn<T>;
  sortDirection: SortDirection;
}

// TODO: all http will change to AuthHttp when authentication is implemented
export abstract class AppService<T> extends BehaviorSubject<T> {
  constructor(protected _http: HttpClient, public apiUrl: string) {
    super(null);
  }

  public getData(
    sourceUrl: string,
    params?: HttpParams
  ): Observable<HttpResponse<T> | T> {
    return this._http
      .get(sourceUrl, { params })
      .pipe(
        map(response => parseResponse(response)),
        catchError(ex => {
          console.log(ex);
          return Observable.throw(ex);
        })
      );
  }

  public putData(
    sourceUrl: string,
    data: any,
    params?: HttpParams
  ): Observable<HttpResponse<T>> {
    return this._http
      .put(sourceUrl, data, { params })
      .pipe(
        map(response => parseResponse(response)),
        catchError(ex => {
          console.log(ex);
          return Observable.throw(ex);
        })
      );
  }

  public postData(
    sourceUrl: string,
    data: any,
    params?: HttpParams
  ): Observable<HttpResponse<T>> {
    return this._http
      .post(sourceUrl, data, { params })
      .pipe(
        map(response => parseResponse(response)),
        catchError(ex => {
          console.log(ex);
          return Observable.throw(ex);
        })
      );
  }

  public deleteData(
    sourceUrl: string,
    params?: HttpParams
  ): Observable<HttpResponse<any>> {
    return this._http
      .delete(sourceUrl, { params })
      .pipe(
        map(response => parseResponse(response)),
        catchError(ex => {
          console.log(ex);
          return Observable.throw(ex);
        })
      );
  }
}

export abstract class ListService<T> extends BehaviorSubject<SearchResult<T>> {

  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _results$ = new BehaviorSubject<T[]>([])
  private _total$ = new BehaviorSubject<number>(0);

  private _state: QueryState<T> = {
    page: 1,
    pageSize: 10,
    parentId: 0,
    searchTerm: '',
    sortColumn: '',
    sortDirection: ''
  };

  set page(page: number) { this._set({ page }); }
  set pageSize(pageSize: number) { this._set({ pageSize }); }
  set parentId(parentId: number) { this._set({ parentId }); }
  set searchTerm(searchTerm: string) { this._set({ searchTerm }); }
  set sortColumn(sortColumn: SortColumn<T>) { this._set({ sortColumn }); }
  set sortDirection(sortDirection: SortDirection) { this._set({ sortDirection }); }

  get results$() { return this._results$.asObservable(); }
  get total$() { return this._total$.asObservable(); }
  get loading$() { return this._loading$.asObservable(); }
  get page() { return this._state.page; }
  get pageSize() { return this._state.pageSize; }
  get searchTerm() { return this._state.searchTerm; }

  constructor(protected _http: HttpClient, private apiUrl: string) {
    super(null);

    this._search$.pipe(
      tap(() => this._loading$.next(true)),
      debounceTime(200),
      switchMap(() => this._search()),
      delay(200),
      tap(() => this._loading$.next(false))
    ).subscribe(result => {
      this._results$.next(result.items);
      this._total$.next(result.totalCount || result.items.length);
    });

    this._search$.next();
  }

  private _set(patch: Partial<QueryState<T>>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  public _search(): Observable<SearchResult<T>> {
    const state = this._state;
    const params = new HttpParams().append('state', JSON.stringify(state));
    return this.getData(this.apiUrl, params);
  }

  public getData(
    sourceUrl: string,
    params?: HttpParams
  ): Observable<SearchResult<T>> {
    return this._http
      .get(sourceUrl, { params })
      .pipe(
        map(response => parseResponse(response)),
        catchError(ex => {
          console.log(ex);
          return Observable.throw(ex);
        })
      );
  }

  public deleteData(params): Promise<Object> {
    return this._http.delete(`${this.apiUrl}/${params.id}`).toPromise();
  }
}

@Injectable({
  providedIn: 'root'
})
export class AppNotificationService {

  constructor() { }

  toasts: any[] = [];

  show(textOrTpl: string | TemplateRef<any>, options: any = {}) {
    this.toasts.push({ textOrTpl, ...options });
  }

  remove(toast) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}


@Injectable({
  providedIn: 'root'
})
export class AuthorizeInterceptor implements HttpInterceptor {
  constructor(private authorize: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return this.authorize.getAccessToken()
      .pipe(mergeMap(token => this.processRequestWithToken(token, req, next)));
  }


  private processRequestWithToken(token: string, req: HttpRequest<any>, next: HttpHandler) {
    if (!!token && this.isSameOriginUrl(req)) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    return next.handle(req);
  }

  private isSameOriginUrl(req: any) {
    // It's an absolute url with the same origin.
    if (req.url.startsWith(`${window.location.origin}/`)) {
      return true;
    }

    // It's a protocol relative url with the same origin.
    // For example: //www.example.com/api/Products
    if (req.url.startsWith(`//${window.location.host}/`)) {
      return true;
    }

    // It's a relative url like /api/Products
    if (/^\/[^\/].*/.test(req.url)) {
      return true;
    }

    // It's an absolute or protocol relative url that
    // doesn't have the same origin.
    return false;
  }
}




@Injectable({
  providedIn: 'root'
})
export class LoginFormService extends AppService<LoginViewModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}schools`);
  }
}

