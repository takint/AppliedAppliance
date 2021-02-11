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
import { PanelMenuComponent } from './panel-menu/panel-menu.component';
import { RouterModule } from '@angular/router';
import { NgbdSortableHeader } from '../common/sortable.directive';

@NgModule({
  declarations: [
    DropdownComponent,
    ConfirmModalComponent,
    NavigationDropdownComponent,
    PanelMenuComponent,
    NgbdSortableHeader
  ],
  providers: [
    NgbModal,
    NgbActiveModal,
    NgbModalConfig,
  ],
  imports: [
    CommonModule,
    NgbModule,
    RouterModule
  ],
  exports: [
    DropdownComponent,
    ConfirmModalComponent,
    NavigationDropdownComponent,
    PanelMenuComponent,
    NgbdSortableHeader
  ]
})
export class SharedComponentsModule { }
