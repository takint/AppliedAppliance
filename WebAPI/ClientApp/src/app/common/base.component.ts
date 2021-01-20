/*
* Do not touch this file if you don't have to.
* The change in here may effect the whole project code.
* If you need to change it, make sure you eventually test the whole app, and passed all the test
*/
import { Observable, forkJoin } from 'rxjs';
import { ActivatedRoute, Params } from '@angular/router';
import {
  QueryList,
  OnInit,
  ViewChildren,
  ViewChild,
  AfterViewChecked
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { ListService, AppService } from './app.service';
import { NgbdSortableHeader, SortEvent } from './sortable.directive';

abstract class BaseComponent {
  constructor() { }

  // TODO: put the common things and abstraction below:

}

export class ListComponent<T> extends BaseComponent implements OnInit {

  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader<T>>;

  // Re-define any to an appropriate class for source data
  public dataSource$: Observable<T[]>;
  public total$: Observable<number>;
  public initData: Array<{ sourceUrl: string, params?: any }> = [];
  public isInitDataLoaded: boolean;

  constructor(protected route: ActivatedRoute, public service: ListService<T>) {
    super()

    this.dataSource$ = this.service.results$;
    this.total$ = this.service.total$;

    this.route.params.subscribe((param: Params) => {
      // TODO: only put init data behavior here when make sure that all list components have that behavior
    });
  }

  onSort({ column, direction }: SortEvent<T>) {
    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }


  ngOnInit() {
    this.route.queryParams.subscribe((params: Params) => {

      let state = params['state'];

      if (this.initData.length > 0) {
        this.loadInitData();
      }
      else {
        this.dataSource$.subscribe(data => {
          if (data.length > 0) {
            this.onInitDataLoaded(data);
            this.isInitDataLoaded = true;
          }
        });
      }
    });
  }

  loadInitData() {
    this.isInitDataLoaded = this.initData.length === 0;
    let requests = [];

    for (let i = 0; i < this.initData.length; i++) {
      requests.push(this.service.getData(this.initData[i].sourceUrl, this.initData[i].params));
    }

    forkJoin(requests).subscribe(
      data => {
        this.onInitDataLoaded(data);
        this.isInitDataLoaded = true;
      },
      error => {
        if (error.errorMessage == 'Unauthorized') {
          // TODO: show some popup instead of logging
          console.log('Unauthorized');
        } else {
          console.log(error.errorMessage);
        }
      },
      () => {
        console.log('Get all data.');
      }
    );
  }

  onInitDataLoaded(data: any): void {

  }


  // TODO: Should move the initData initialization into this function if its element contains params as variables.
  setInitDataSourcesAndParams() {

  }

  onDeleteClick(event, data: T) {

  }
}

export class FormComponent<T> extends BaseComponent implements AfterViewChecked, OnInit {
  mainForm: NgForm;
  @ViewChild('mainForm', null) currentForm: NgForm;

  public initData: Array<{ sourceUrl: string, params?: any }> = [];
  public isInitDataLoaded: boolean;

  public isViewMode: boolean;
  public isEditMode: boolean;
  public isAddMode: boolean;

  public modelId: number;
  public modelName: string;
  public modelIdParam: string = 'id';

  public model: T;
  public updateModel: T;

  protected isModelSubmitted: boolean;
  protected elements: any = {};

  public isSaving: boolean;

  constructor(protected route: ActivatedRoute, public service: AppService) {
    super();

  }

  ngOnInit() { }

  ngAfterViewChecked() { }
}
