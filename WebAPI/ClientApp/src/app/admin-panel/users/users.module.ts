import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './user-list/user-list.component';
import { UserFormsComponent } from './user-forms/user-forms.component';
import { RouterModule } from '@angular/router';
import { UserFormService, UserListService } from './users.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';

const ADMIN_PANEL_USER_ROUTE = [
  { path: '', component: UserListComponent, pathMatch: 'full' },
  { path: 'details/:id/:mode', component: UserFormsComponent },
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    SharedComponentsModule,
    RouterModule.forChild(ADMIN_PANEL_USER_ROUTE)
  ],
  declarations: [UserListComponent, UserFormsComponent ],
  providers: [
    UserListService,
    UserFormService
  ]
})
export class UsersModule { }
