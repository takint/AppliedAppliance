import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DropdownComponent } from './dropdown/dropdown.component';
import { ConfirmModalComponent } from './confirm-modal/confirm-modal.component';
import {
  NgbModalConfig,
  NgbModal,
  NgbActiveModal,
  NgbModule
} from '@ng-bootstrap/ng-bootstrap';
import { NavigationDropdownComponent } from './navigation-dropdown/navigation-dropdown.component';

@NgModule({
  declarations: [
    DropdownComponent,
    ConfirmModalComponent,
    NavigationDropdownComponent
  ],
  providers: [
    NgbModal,
    NgbActiveModal,
    NgbModalConfig,
  ],
  imports: [
    CommonModule,
    NgbModule
  ],
  exports: [
    DropdownComponent,
    ConfirmModalComponent,
    NavigationDropdownComponent
  ]
})
export class SharedComponentsModule { }
