import { NgTemplateOutlet } from '@angular/common';
import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { NgbModalConfig, NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.scss']
})
export class ConfirmModalComponent {
  @ViewChild('content') content: NgTemplateOutlet;

  constructor(config: NgbModalConfig, private modalService: NgbModal) {
    config.backdrop = true;
    config.keyboard = false;
  }

  @Output() onOpenModal: EventEmitter<NgbModalRef> = new EventEmitter();
  @Input() entityName: string;
  @Input() public set openModal(isOpen: boolean) {
    if (isOpen) {
      let modalRef = this.modalService.open(this.content, { centered: true });
      this.onOpenModal.emit(modalRef);
    }
  }
}
