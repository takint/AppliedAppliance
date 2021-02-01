/*
* Do not touch this file if you don't have to.
* The change in here may effect the whole project code.
* If you need to change it, make sure you eventually test the whole app, and passed all the test
*/
import { Observable, forkJoin } from 'rxjs';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { QueryList, OnInit, ViewChildren, ViewChild, AfterViewChecked, Directive } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ListService, AppService, AppNotificationService } from './app.service';
import { NgbdSortableHeader, SortEvent } from './sortable.directive';
import { AppUtil } from './app.util';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

abstract class BaseComponent {
  constructor(protected notiService: AppNotificationService) { }

  // TODO: put the common things and abstraction below:

}

@Directive()
export class ListComponent<T> extends BaseComponent implements OnInit {

  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader<T>>;

  // Re-define any to an appropriate class for source data
  public dataSource$: Observable<T[]>;
  public total$: Observable<number>;
  public confirmModal: NgbModalRef;
  public initData: Array<{ sourceUrl: string, params?: any }> = [];
  public isInitDataLoaded: boolean;
  public isOpenConfirmModal: boolean = false;
  protected selectedEntry: T;

  constructor(protected route: ActivatedRoute, public service: ListService<T>, protected notiService: AppNotificationService) {
    super(notiService)

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
          this.onInitDataLoaded(data);
          this.isInitDataLoaded = true;
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
          this.notiService.show('Unauthorized', { classname: AppUtil.toastErrorClass });
        } else {
          this.notiService.show(`There is error onload: ${error.errorMessage}`, { classname: AppUtil.toastErrorClass });
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

  onRowDeleted() {
    // Reload data on table
    this.service.searchTerm = "";
    this.isInitDataLoaded = false;
  }

  onDeleteClick(event, data: T) {
    this.isOpenConfirmModal = true;
    this.selectedEntry = data;
  }

  onOpenModal(modal) {
    modal.result.then(
      async res => {
        this.isInitDataLoaded = true;
        await this.service.deleteData(this.selectedEntry);
        this.isOpenConfirmModal = false;
        this.onRowDeleted();
      },
      reason => {
        this.isOpenConfirmModal = false;
      }
    );
  }
}

@Directive()
export class FormComponent<T> extends BaseComponent implements AfterViewChecked, OnInit {
  mainForm: NgForm;
  @ViewChild('mainForm') currentForm: NgForm;

  public initData: Array<{ sourceUrl: string, params?: any }> = [];
  public isInitDataLoaded: boolean = false;

  public isViewMode: boolean;
  public isEditMode: boolean;
  public isAddMode: boolean;

  public modelId: number;
  public modelName: string;
  public modelIdParam: string = 'id';
  public formUrl: string;
  public listUrl: string;

  public model: T;
  public updateModel: T;
  public responseModel: any;

  protected isModelSubmitted: boolean;
  protected elements: any = {};

  public isSaving: boolean;

  constructor(protected route: ActivatedRoute,
    protected router: Router,
    public service: AppService<T>,
    protected notiService: AppNotificationService
  ) {
    super(notiService);
    this.routingHandler();
  }

  ngOnInit() {
    this.prepareModel();
  }

  /* Will be implement in the concrete class */
  onInitDataLoaded(data) { }
  onSubmitSuccess() { }
  prepareModelForViewOrEditMode() { }
  prepareModelForAddMode() { }
  prepareModelForSubmit() { }
  doCustomValidationOnSubmit(): string {
    return null;
  }

  // TODO has this been called/used anywhere?
  onEditClick() {
    this.route.params['mode'] = 'edit';
  }

  routingHandler() {
    this.route.params.subscribe((param: Params) => {
      let formMode = param['mode'] ? param['mode'].toLowerCase() : 'view';

      this.modelId = param[this.modelIdParam];

      // This will go step by step
      this.setFormMode(formMode);

      this.prepareModel();

      this.loadInitData();

      this.isModelSubmitted = false;
    });
  }

  loadInitData() {
    this.isInitDataLoaded = this.initData.length === 0;

    let requests = [];

    for (let i = 0; i < this.initData.length; i++) {
      requests.push(this.service.getData(this.initData[i].sourceUrl, this.initData[i].params));
    }

    forkJoin(requests)
      .subscribe(data => {
        if (!this.isAddMode && !AppUtil.isNullOrEmpty(this.modelName)) {
          this.model = data[data.length - 1] as T;
          if (this.model == null) {
            window.location.href = `Home/Error/?errorCode=404`;
          }
        }

        this.onInitDataLoaded(data);
        this.isInitDataLoaded = true;
      }, error => {
        if (error.errorMessage == "Unauthorized") {
          this.notiService.show('Unauthorized', { classname: AppUtil.toastErrorClass });
        } else {
          this.notiService.show(`There is error onload: ${error.errorMessage}`, { classname: AppUtil.toastErrorClass });
        }
      }, () => {
        console.log('Model loaded');
      });
  }

  setFormMode(formMode) {
    this.isViewMode = formMode === 'view';
    this.isEditMode = formMode === 'edit';
    this.isAddMode = formMode === 'add';
  }

  prepareModel() {
    if (this.isViewMode || this.isEditMode) {
      this.prepareModelForViewOrEditMode();
    } else {
      this.prepareModelForAddMode();
    }
  }

  onSubmit() {
    let errorMessage = null;

    this.prepareModelForSubmit();

    if (this.mainForm.invalid) {
      errorMessage = 'mandatoryFieldsValidation';
    } else {
      errorMessage = this.doCustomValidationOnSubmit();
    }

    if (AppUtil.isNullOrEmpty(errorMessage)) {
      this.isSaving = true;

      if (this.modelId > 0) { // Update
        this.submitUpdatedModel();
      } else { // Add new
        this.submitNewModel();
      }
    } else {
      this.notiService.show(errorMessage, { classname: AppUtil.toastErrorClass });
      this.validateAllFields(false);
    }

    return errorMessage;
  }

  submitUpdatedModel() {
    this.service.putData(`${this.service.apiUrl}/${this.modelId}`, this.model,)
      .subscribe(res => {
        this.onSubmitSuccess();

        this.isSaving = false;
        this.isModelSubmitted = true;

        this.router.navigate([this.listUrl]);
      }, error => {
        this.isSaving = false;
        this.notiService.show(`There is error on save: ${error}`, { classname: AppUtil.toastErrorClass });
      }, () => {
        console.log('Model submitted');
      });
  }

  submitNewModel() {
    this.service.postData(this.service.apiUrl, this.model)
      .subscribe(res => {
        this.onSubmitSuccess();

        this.isSaving = false;
        this.isModelSubmitted = true;

        this.router.navigate([this.listUrl]);
        console.log(res);
      }, error => {
        this.isSaving = false;
        this.notiService.show(`There is error on save: ${error}`, { classname: AppUtil.toastErrorClass });
      }, () => {
        console.log('Model submitted');
      });
  }

  /* ==== FORM VALIDATION ==== */
  formErrors = {};

  // To be  overwritten in derived class
  validationRules = {};

  ngAfterViewChecked() {
    this.formChanged();
  }

  formChanged() {
    if (this.currentForm === this.mainForm) { return; }
    this.mainForm = this.currentForm;
    if (this.mainForm) {
      this.mainForm.valueChanges
        .subscribe(data => this.onValueChanged(data));
    }
  }

  onValueChanged(data?: any) {
    this.validateAllFields(true);
  }

  validateAllFields(checkDirty: boolean) {
    if (!this.mainForm) { return; }
    const form = this.mainForm.form;

    for (const field in this.validationRules) {
      this.formErrors[field] = '';
      const control = form.get(field);

      if (control && (control.dirty || !checkDirty) && !control.valid) {
        const messages = this.validationRules[field];
        for (const key in control.errors) {
          this.formErrors[field] += messages[key] + ' ';
        }
        control.markAsDirty();
      }
    }
  }

}
