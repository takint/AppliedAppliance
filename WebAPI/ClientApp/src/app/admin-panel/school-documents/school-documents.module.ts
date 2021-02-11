import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SchoolDocumentListComponent } from './school-document-list/school-document-list.component';
import { SchoolDocumentFormsComponent } from './school-document-forms/school-document-forms.component';
import { SchoolDocumentFormService, SchoolDocumentListService } from './school-document.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    SchoolDocumentListComponent,
    SchoolDocumentFormsComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    SharedComponentsModule,
    RouterModule
  ],
  providers: [
    SchoolDocumentListService,
    SchoolDocumentFormService
  ],
  exports: [
    SchoolDocumentListComponent,
    SchoolDocumentFormsComponent
  ]
})
export class SchoolDocumentsModule { }
