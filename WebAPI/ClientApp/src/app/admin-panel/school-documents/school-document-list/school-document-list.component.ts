import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { ListComponent } from '../../../common/base.component';
import { SchoolDocumentModel } from '../../../common/models/school-document-model';
import { SchoolDocumentListService } from '../school-document.service';

@Component({
  selector: 'app-school-document-list',
  templateUrl: './school-document-list.component.html',
  styleUrls: ['./school-document-list.component.scss']
})
export class SchoolDocumentListComponent extends ListComponent<SchoolDocumentModel> implements OnInit {

  constructor(protected route: ActivatedRoute,
    public service: SchoolDocumentListService,
    protected notiService: AppNotificationService) {
    super(route, service, notiService);
  }

  ngOnInit(): void {
  }

}
