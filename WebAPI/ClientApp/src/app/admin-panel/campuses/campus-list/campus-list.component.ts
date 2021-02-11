import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { ListComponent } from '../../../common/base.component';
import { CampusModel } from '../../../common/models/campus-model';
import { CampusListService } from '../campus.service';

@Component({
  selector: 'app-campus-list',
  templateUrl: './campus-list.component.html',
  styleUrls: ['./campus-list.component.scss']
})
export class CampusListComponent extends ListComponent<CampusModel> implements OnInit {

  constructor(protected route: ActivatedRoute,
    public service: CampusListService,
    protected notiService: AppNotificationService) {
    super(route, service, notiService);
  }

  @Input() schoolId: number = 0; //to be used for getting the campus based on the school

  ngOnInit(): void {
    this.service.parentId = this.schoolId;
  }

}
