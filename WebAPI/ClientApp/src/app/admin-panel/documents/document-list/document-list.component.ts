import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { ListComponent } from '../../../common/base.component';
import { DocumentModel } from '../../../common/models/document-model';
import { DocumentListService } from '../document.service';

@Component({
  selector: 'app-document-list',
  templateUrl: './document-list.component.html',
  styleUrls: ['./document-list.component.scss']
})

export class DocumentListComponent extends ListComponent<DocumentModel> implements OnInit {
  constructor(protected route: ActivatedRoute,
    public service: DocumentListService,
    protected notiService: AppNotificationService) {
    super(route, service, notiService);
  }

  ngOnInit(): void {
  }

}
