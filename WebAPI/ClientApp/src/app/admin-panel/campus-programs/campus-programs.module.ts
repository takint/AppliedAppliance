import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampusProgramListComponent } from './campus-program-list/campus-program-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';
import { CampusFormService, CampusListService } from '../campuses/campus.service';



@NgModule({
  declarations: [
    CampusProgramListComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    SharedComponentsModule,
  ],
  providers: [
    CampusListService,
    CampusFormService
  ],
  exports: [
    CampusProgramListComponent,
  ]
})
export class CampusProgramsModule { }
