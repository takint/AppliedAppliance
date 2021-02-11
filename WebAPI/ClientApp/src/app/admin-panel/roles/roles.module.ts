import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleListComponent } from './role-list/role-list.component';
import { RoleFormsComponent } from './role-forms/role-forms.component';
import { RouterModule } from '@angular/router';

const ADMIN_PANEL_ROLE_ROUTE = [
  { path: '', component: RoleListComponent, pathMatch: 'full' },
  { path: 'details/:id/:mode', component: RoleFormsComponent },
];

@NgModule({
  declarations: [RoleListComponent, RoleFormsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(ADMIN_PANEL_ROLE_ROUTE),
  ]
})
export class RolesModule { }
