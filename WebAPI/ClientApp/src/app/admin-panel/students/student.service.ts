import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { StudentModel } from '../../common/models/student-model';

@Injectable({
  providedIn: 'root'
})
export class StudentListService extends ListService<StudentModel> {

  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}students`);
  }
}
