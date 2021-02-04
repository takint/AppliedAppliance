import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService, ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { ProgramFormViewModel, ProgramModel } from '../../common/models/program-model';

@Injectable({
  providedIn: 'root'
})
export class ProgramListService extends ListService<ProgramModel> {

  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}programs`);
  }
}

@Injectable({
  providedIn: 'root'
})

export class ProgramFormService extends AppService<ProgramFormViewModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}programs`);
  }
}
