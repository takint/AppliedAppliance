import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppUtil } from '../../common/app.util';
import { AppService, ListService } from '../../common/app.service';
import { SchoolModel, SchoolFormViewModel } from '../../common/models/school-model';

@Injectable({
  providedIn: 'root'
})
export class SchoolListService extends ListService<SchoolModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}schools`);
  }
}


@Injectable({
  providedIn: 'root'
})
export class SchoolFormService extends AppService<SchoolFormViewModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}schools`);
  }
}
