import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService, ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { ProgramCategoryFormViewModel, ProgramCategoryModel } from '../../common/models/program-category-model';

@Injectable({
  providedIn: 'root'
})
export class ProgramCategoryListService extends ListService<ProgramCategoryModel> {

  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}programCategories`);
  }
}

@Injectable({
  providedIn: 'root'
})
export class ProgramCategoryFormService extends AppService<ProgramCategoryFormViewModel> {

  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}programCategories`);
  }
}
