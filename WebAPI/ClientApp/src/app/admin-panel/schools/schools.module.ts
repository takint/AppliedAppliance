import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbdSortableHeader } from '../../common/sortable.directive';
import { SchoolListService } from './school.service';
import { SchoolListComponent } from './school-list/school-list.component';
import { SchoolFormsComponent } from './school-forms/school-forms.component';

const ADMIN_PANEL_SCHOOL_ROUTE = [
  { path: '', component: SchoolListComponent, pathMatch: 'full' },
  { path: 'Details/:id', component: SchoolFormsComponent },
];


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule.forChild(ADMIN_PANEL_SCHOOL_ROUTE)
  ],
  declarations: [
    SchoolListComponent,
    SchoolFormsComponent,
    NgbdSortableHeader
  ],
  providers: [
    SchoolListService
  ]
})
export class SchoolsModule { }
