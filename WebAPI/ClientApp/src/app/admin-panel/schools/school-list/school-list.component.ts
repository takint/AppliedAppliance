import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SchoolListService } from '../school.service';
import { SchoolModel } from '../../../common/models/school-model';
import { ListComponent } from '../../../common/base.component';
import { AppNotificationService } from '../../../common/app.service';

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
