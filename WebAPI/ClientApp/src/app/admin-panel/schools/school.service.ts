import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AppUtil } from '../../common/app.util';
import { AppService, ListService } from '../../common/app.service';
import { SchoolModel } from '../../common/models/school-models';

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
export class SchoolFormService extends AppService {

  public apiUrl: string = `${AppUtil.apiHost}schools`;

  constructor(http: HttpClient) {
    super(http);
  }
}
