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
  HttpUserEvent
} from '@angular/common/http';
import { Injectable, TemplateRef } from '@angular/core';
import { Observable, BehaviorSubject, of, Subject } from 'rxjs';
import { map, catchError, switchMap, tap, debounceTime, delay } from 'rxjs/operators';

import { parseResponse } from './app.util';
import { SortColumn, SortDirection } from './sortable.directive'


interface SearchResult {
  lists: any[];
  total: number;
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
export abstract class AppService extends BehaviorSubject<any> {
  constructor(protected _http: HttpClient) {
    super(null);
  }

  public getData(
    sourceUrl: string,
    params?: any
  ): Observable<HttpResponse<any>> {
    return this._http
      .get(sourceUrl, params)
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
    params?: any
  ): Observable<HttpResponse<any>> {
    return this._http
      .put(sourceUrl, data, params)
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
    params?: any
  ): Observable<HttpResponse<any>> {
    return this._http
      .post(sourceUrl, data, params)
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
    params?: any
  ): Observable<HttpResponse<any>> {
    return this._http
      .delete(sourceUrl, params)
      .pipe(
        map(response => parseResponse(response)),
        catchError(ex => {
          console.log(ex);
          return Observable.throw(ex);
        })
      );
  }
}

export abstract class ListService<T> extends BehaviorSubject<SearchResult> {

  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _results$ = new BehaviorSubject<any[]>([])
  private _total$ = new BehaviorSubject<number>(0);

  private _state: QueryState<T> = {
    page: 1,
    pageSize: 20,
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
      this._results$.next(result.lists);
      this._total$.next(result.total || result.lists.length);
    });

    this._search$.next();
  }

  private _set(patch: Partial<QueryState<T>>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  public _search(): Observable<SearchResult> {
    const { sortColumn, sortDirection, pageSize, page, searchTerm } = this._state;
    // TODO: put param for state filter and paging
    console.log(sortColumn);
    console.log(sortDirection);
    console.log(pageSize);
    console.log(page);
    return this.getData(this.apiUrl, {});
  }

  public getData(
    sourceUrl: string,
    params?: any
  ): Observable<SearchResult> {
    return this._http
      .get(sourceUrl, params)
      .pipe(
        map(response => parseResponse(response)),
        catchError(ex => {
          console.log(ex);
          return Observable.throw(ex);
        })
      );
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
