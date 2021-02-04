import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { AppService, ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { StudentFormViewModel, StudentModel } from '../../common/models/student-model';

@Injectable({
  providedIn: 'root'
})
export class StudentListService extends ListService<StudentModel> {

  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}students`);
  }
}

@Injectable({
  providedIn: 'root'
})

export class StudentFormService extends AppService<StudentFormViewModel>{
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}students`);
  }
}
