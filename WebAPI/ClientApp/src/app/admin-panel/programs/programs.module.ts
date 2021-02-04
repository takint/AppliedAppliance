import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProgramListComponent } from './program-list/program-list.component';
import { ProgramFormService, ProgramListService } from './program.service';
import { RouterModule } from '@angular/router';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProgramFormsComponent } from './program-forms/program-forms.component';

const ADMIN_PANEL_PROGRAM_ROUTE = [
  //{ path: 'Program', component: ProgramListComponent, pathMatch: 'full' }
  //{ path: 'Programs/Details/:id/:mode', component: ProgramFormsComponent }
];

@NgModule({
  declarations: [
    ProgramListComponent,
    ProgramFormsComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    SharedComponentsModule,
    RouterModule.forChild(ADMIN_PANEL_PROGRAM_ROUTE)
  ],
  providers: [
    ProgramListService,
    ProgramFormService
  ],
  exports: [
    ProgramListComponent,
    ProgramFormsComponent
  ]
})
export class ProgramsModule { }
