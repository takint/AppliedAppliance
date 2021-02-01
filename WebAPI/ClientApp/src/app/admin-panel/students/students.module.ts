import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentListComponent } from './student-list/student-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { StudentListService } from './student.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';


const ADMIN_PANEL_STUDENT_ROUTE = [
  { path: '', component: StudentListComponent, pathMatch: 'full' },
  //{ path: '', component: }
];


@NgModule({

  declarations: [
    StudentListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    SharedComponentsModule,
    RouterModule.forChild(ADMIN_PANEL_STUDENT_ROUTE)
  ],
  providers: [
    StudentListService
  ]
})
export class StudentsModule { }
