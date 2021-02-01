import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { SchoolListService } from '../school.service';
import { SchoolModel } from '../../../common/models/school-model';
import { ListComponent } from '../../../common/base.component';
import { AppNotificationService } from '../../../common/app.service';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { AppUtil } from '../../../common/app.util';

@Component({
  selector: 'app-school-list',
  templateUrl: './school-list.component.html',
  styleUrls: ['./school-list.component.scss']
})
export class SchoolListComponent extends ListComponent<SchoolModel> implements OnInit {

  constructor(protected route: ActivatedRoute,
    public service: SchoolListService,
    protected notiService: AppNotificationService) {
    super(route, service, notiService);
  }
}
