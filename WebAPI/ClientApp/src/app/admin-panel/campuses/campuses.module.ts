import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampusListComponent } from './campus-list/campus-list.component';
import { CampusFormService, CampusListService } from './campus.service';
import { RouterModule } from '@angular/router';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CampusFormsComponent } from './campus-forms/campus-forms.component';

const ADMIN_PANEL_CAMPUS_ROUTE = [
  //{ path: '', component: CampusListComponent, pathMatch: 'full' }
];

@NgModule({
  declarations: [
    CampusListComponent,
    CampusFormsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    SharedComponentsModule,
    RouterModule.forChild(ADMIN_PANEL_CAMPUS_ROUTE),
  ],
  providers: [
    CampusListService,
    CampusFormService
  ],
  exports: [
    CampusListComponent,
  ]
})
export class CampusesModule { }
