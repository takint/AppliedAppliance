import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppService, ListService } from '../../common/app.service';
import { AppUtil } from '../../common/app.util';
import { UserModel, UserViewModel } from '../../common/models/user-model';

@Injectable({
  providedIn: 'root'
})
export class UserListService extends ListService<UserModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}users`);
  }
}


@Injectable({
  providedIn: 'root'
})
export class UserFormService extends AppService<UserViewModel> {
  constructor(http: HttpClient) {
    super(http, `${AppUtil.apiHost}users`);
  }
}
