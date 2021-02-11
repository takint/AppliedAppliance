import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService, ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { CampusFormViewModel, CampusModel } from '../../common/models/campus-model';

@Injectable({
  providedIn: 'root'
})

export class CampusListService extends ListService<CampusModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}campuses`);
  }
}

@Injectable({
  providedIn: 'root'
})

export class CampusFormService extends AppService<CampusFormViewModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}campuses`);
  }

  public createUpdateCampus(data: CampusModel, schoolId: number) {
    return this.putData(this.apiUrl, data, new HttpParams().append('id', schoolId.toString()));
  }
}
