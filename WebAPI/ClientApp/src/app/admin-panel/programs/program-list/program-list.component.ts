import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { ListComponent } from '../../../common/base.component';
import { ProgramModel } from '../../../common/models/program-model';
import { ProgramListService } from '../program.service';

@Component({
  selector: 'app-program-list',
  templateUrl: './program-list.component.html',
  styleUrls: ['./program-list.component.scss']
})
export class ProgramListComponent extends ListComponent<ProgramModel> implements OnInit {
  constructor(protected route: ActivatedRoute,
    public service: ProgramListService,
    protected notiService: AppNotificationService) {
    super(route, service, notiService);
  }

  ngOnInit(): void {
  }

}
