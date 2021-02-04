import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProgramCategoryListComponent } from './program-category-list/program-category-list.component';
import { ProgramCategoryFormsComponent } from './program-category-forms/program-category-forms.component';
import { RouterModule } from '@angular/router';
import { ProgramCategoryFormService, ProgramCategoryListService } from './program-category.service';
import { SharedComponentsModule } from '../../shared-components/shared-components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


const ADMIN_PANEL_PROGRAM_CATEGORY_ROUTE = [
  { path: '', component: ProgramCategoryListComponent, pathMatch: 'full' },
  { path: 'details/:id/:mode', component: ProgramCategoryFormsComponent }
];

@NgModule({
  declarations: [
    ProgramCategoryListComponent,
    ProgramCategoryFormsComponent
  ],

  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    SharedComponentsModule,
    RouterModule.forChild(ADMIN_PANEL_PROGRAM_CATEGORY_ROUTE)
  ],

  providers: [
    ProgramCategoryListService,
    ProgramCategoryFormService
  ]
})
export class ProgramCategoriesModule { }
