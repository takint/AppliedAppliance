import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SchoolPanelComponent } from './school-panel/school-panel.component';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedComponentsModule } from '../shared-components/shared-components.module';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from '../admin-panel/dashboard/dashboard.component';
import { SchoolFormsComponent } from '../admin-panel/schools/school-forms/school-forms.component';
import { CampusListComponent } from '../admin-panel/campuses/campus-list/campus-list.component';
import { ProgramListComponent } from '../admin-panel/programs/program-list/program-list.component';
import { ProgramCategoryListComponent } from '../admin-panel/program-categories/program-category-list/program-category-list.component';

const SCHOOL_PANEL_ROUTE = [
  {
    path: '', component: SchoolPanelComponent, children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'details', component: SchoolFormsComponent },
      { path: 'campuses', component: CampusListComponent },
      { path: 'programs', component: ProgramListComponent },
      { path: 'program-categories', component: ProgramCategoryListComponent },
    ]
  },
];

@NgModule({
  declarations: [
    SchoolPanelComponent,
  ],

  imports: [
    CommonModule,
    NgbModule,
    SharedComponentsModule,
    RouterModule.forChild(SCHOOL_PANEL_ROUTE),
  ],

  providers: [
    NgbActiveModal
  ]
})
export class SchoolPanelModule { }
