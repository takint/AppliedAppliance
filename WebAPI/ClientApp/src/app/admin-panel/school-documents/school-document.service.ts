import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService, ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { SchoolDocumentFormViewModel, SchoolDocumentModel } from '../../common/models/school-document-model';

@Injectable({
  providedIn: 'root'
})
export class SchoolDocumentListService extends ListService<SchoolDocumentModel> {

  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}schooldocuments`);
  }
}

@Injectable({
  providedIn: 'root'
})
export class SchoolDocumentFormService extends AppService<SchoolDocumentFormViewModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}schooldocuments`);
  }
}
