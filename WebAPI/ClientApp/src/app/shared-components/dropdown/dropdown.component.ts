import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.scss']
})
export class DropdownComponent {

  @Input() dropDownHeader: string;
  @Input() dropDownItems: Array<DropDownItems>;

  constructor() {
  }
}

export interface DropDownItems {
  title: string;
  url: string;
  icon: string;
}
