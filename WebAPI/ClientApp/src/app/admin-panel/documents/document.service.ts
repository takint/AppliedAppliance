import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService, ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { DocumentFormViewModel, DocumentModel } from '../../common/models/document-model';

@Injectable({
  providedIn: 'root'
})
export class DocumentListService extends ListService<DocumentModel> {

  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}documents`);
  }
}

@Injectable({
  providedIn: 'root'
})

export class DocumentFormService extends AppService<DocumentFormViewModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}documents`);
  }
}
