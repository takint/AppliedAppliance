import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DocumentListComponent } from './document-list/document-list.component';
import { DocumentFormsComponent } from './document-forms/document-forms.component';
import { DocumentFormService, DocumentListService } from './document.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';
import { RouterModule } from '@angular/router';


const ADMIN_PANEL_DOCUMENT_ROUTE = [
  { path: '', component: DocumentListComponent, pathMatch: 'full' },
  { path: 'details/:id/:mode', component: DocumentFormsComponent }
];

@NgModule({
  declarations: [
    DocumentListComponent,
    DocumentFormsComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    SharedComponentsModule,
    RouterModule.forChild(ADMIN_PANEL_DOCUMENT_ROUTE)
  ],
  providers: [
    DocumentListService,
    DocumentFormService
  ],
  exports: [
    DocumentListComponent,
    DocumentFormsComponent
  ]
})
export class DocumentsModule { }
