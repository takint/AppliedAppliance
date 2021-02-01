import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { ListComponent } from '../../../common/base.component';
import { StudentModel } from '../../../common/models/student-model';
import { StudentListService } from '../student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss']
})

export class StudentListComponent extends ListComponent<StudentModel> implements OnInit {

  constructor(protected route: ActivatedRoute,
    public service: StudentListService,
    protected notiService: AppNotificationService) {

    super(route, service, notiService);
  }
}
