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
  HttpErrorResponse,
  HttpSentEvent,
  HttpHeaderResponse,
  HttpProgressEvent,
  HttpUserEvent,
  HttpParams
} from '@angular/common/http';
import { Injectable, TemplateRef } from '@angular/core';
import { Observable, BehaviorSubject, of, Subject } from 'rxjs';
import { map, catchError, switchMap, tap, debounceTime, delay } from 'rxjs/operators';

import { AppUtil, parseResponse } from './app.util';
import { LoginViewModel } from './models/user-model';
import { SortColumn, SortDirection } from './sortable.directive'


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
    searchTerm: '',
    sortColumn: '',
    sortDirection: ''
  };

  set page(page: number) { this._set({ page }); }
  set pageSize(pageSize: number) { this._set({ pageSize }); }
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
    return this.getData(this.apiUrl, new HttpParams().append('state', JSON.stringify(state)));
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
export class LoginFormService extends AppService<LoginViewModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}schools`);
  }
}
