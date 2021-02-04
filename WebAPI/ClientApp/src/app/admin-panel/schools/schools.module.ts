import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';
import { NgbdSortableHeader } from '../../common/sortable.directive';
import { SchoolFormService, SchoolListService } from './school.service';
import { SchoolListComponent } from './school-list/school-list.component';
import { SchoolFormsComponent } from './school-forms/school-forms.component';
import { CampusListComponent } from '../campuses/campus-list/campus-list.component';
import { CampusesModule } from '../campuses/campuses.module';
import { ProgramsModule } from '../programs/programs.module';
import { ProgramFormsComponent } from '../programs/program-forms/program-forms.component';
import { ProgramListComponent } from '../programs/program-list/program-list.component';

const ADMIN_PANEL_SCHOOL_ROUTE = [
  { path: '', component: SchoolListComponent, pathMatch: 'full' },
  { path: 'details/:id/:mode', component: SchoolFormsComponent },
  //{ path: 'Campuses', component: CampusListComponent },
  { path: 'programs', component: ProgramListComponent },
  { path: 'programs/details/:id/:mode', component: ProgramFormsComponent }
];


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    SharedComponentsModule,
    CampusesModule,
    ProgramsModule,
    RouterModule.forChild(ADMIN_PANEL_SCHOOL_ROUTE)
  ],
  declarations: [
    SchoolListComponent,
    SchoolFormsComponent,
    NgbdSortableHeader
  ],
  providers: [
    SchoolListService,
    SchoolFormService
  ]
})
export class SchoolsModule { }
