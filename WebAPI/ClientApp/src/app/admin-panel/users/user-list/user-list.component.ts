import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppNotificationService } from '../../../common/app.service';
import { ListComponent } from '../../../common/base.component';
import { UserModel } from '../../../common/models/user-model';
import { UserListService } from '../users.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent extends ListComponent<UserModel> implements OnInit {

  constructor(protected route: ActivatedRoute,
    public service: UserListService,
    protected notiService: AppNotificationService) {
    super(route, service, notiService);
  }
}
