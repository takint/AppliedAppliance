import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { SchoolListService } from '../school.service';
import { SchoolModel } from '../../../common/models/school-models';
import { ListComponent } from '../../../common/base.component';

@Component({
  selector: 'app-school-list',
  templateUrl: './school-list.component.html',
  styleUrls: ['./school-list.component.scss']
})
export class SchoolListComponent extends ListComponent<SchoolModel> implements OnInit {
  constructor(protected route: ActivatedRoute,
    public service: SchoolListService) {
    super(route, service);
  }
}
