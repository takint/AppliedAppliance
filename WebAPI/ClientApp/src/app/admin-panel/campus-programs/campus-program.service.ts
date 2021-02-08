import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService, ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { CampusProgramFormViewModel, CampusProgramModel } from '../../common/models/campus-program-model';

@Injectable({
  providedIn: 'root'
})
export class CampusProgramListService extends ListService<CampusProgramModel> {

  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}campusprograms`);
  }
}

@Injectable({
  providedIn: 'root'
})

export class CampusProgramFormService extends AppService<CampusProgramFormViewModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}campusprograms`);
  }
}
