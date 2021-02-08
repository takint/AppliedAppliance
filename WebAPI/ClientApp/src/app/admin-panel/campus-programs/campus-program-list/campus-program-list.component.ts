import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { ListComponent } from '../../../common/base.component';
import { CampusProgramModel } from '../../../common/models/campus-program-model';
import { CampusProgramListService } from '../campus-program.service';

@Component({
  selector: 'app-campus-program-list',
  templateUrl: './campus-program-list.component.html',
  styleUrls: ['./campus-program-list.component.scss']
})
export class CampusProgramListComponent extends ListComponent<CampusProgramModel> implements OnInit {
  constructor(protected route: ActivatedRoute,
    public service: CampusProgramListService,
    protected notiService: AppNotificationService) {
    super(route, service, notiService);
  }

  ngOnInit(): void {
  }

}
