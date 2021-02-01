import { Component, OnInit } from '@angular/core';
import { DropDownItems } from '../../shared-components/dropdown/dropdown.component';

@Component({
  selector: 'app-panel-header',
  templateUrl: './panel-header.component.html',
  styleUrls: ['./panel-header.component.scss']
})
export class PanelHeaderComponent implements OnInit {

  dropDownTitle: string = 'admin@admin.com';

  dropDownList: Array<DropDownItems> = [
    { title: 'Schools', url: 'Schools', icon: 'far fa-user mr-2' },
    { title: 'Students', url: 'Students', icon: 'fas fa-wrench mr-2' },
    { title: 'Agents', url: 'Agents', icon: 'fa-sign-out-alt mr-2' },
  ];

  constructor() { }

  ngOnInit() {
  }

}
