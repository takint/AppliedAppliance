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
import { CampusProgramsModule } from '../campus-programs/campus-programs.module';
import { CampusProgramListComponent } from '../campus-programs/campus-program-list/campus-program-list.component';
import { CampusFormsComponent } from '../campuses/campus-forms/campus-forms.component';
import { SchoolDocumentsModule } from '../school-documents/school-documents.module';
import { SchoolDocumentListComponent } from '../school-documents/school-document-list/school-document-list.component';
import { SchoolDocumentFormsComponent } from '../school-documents/school-document-forms/school-document-forms.component';
import { AuthService } from '../../common/auth.service';

const ADMIN_PANEL_SCHOOL_ROUTE = [
  { path: '', component: SchoolListComponent, pathMatch: 'full' },
  { path: 'details/:id/:mode', component: SchoolFormsComponent },
  { path: 'campuses', component: CampusListComponent },
  { path: 'campuses/details/:id/:mode', component: CampusFormsComponent },
  { path: 'programs', component: ProgramListComponent },
  { path: 'programs/details/:id/:mode', component: ProgramFormsComponent },
  { path: 'campus-programs', component: CampusProgramListComponent },
  { path: 'school-documents', component: SchoolDocumentListComponent },
  { path: 'school-documents/details/:id/:mode', component: SchoolDocumentFormsComponent },
  //{ path: 'campus-programs/details/:id/:mode', component: ProgramFormsComponent }
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
    CampusProgramsModule,
    SchoolDocumentsModule,
    RouterModule.forChild(ADMIN_PANEL_SCHOOL_ROUTE)
  ],
  declarations: [
    SchoolListComponent,
    SchoolFormsComponent
  ],
  providers: [
    SchoolListService,
    SchoolFormService,
    AuthService
  ]
})
export class SchoolsModule { }
