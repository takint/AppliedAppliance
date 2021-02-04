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
    { title: 'Profile', url: 'authentication/profile', icon: 'far fa-user mr-2' },
    { title: 'Settings', url: 'admin/settings', icon: 'fas fa-wrench mr-2' },
    { title: 'Logout', url: 'authentication/logout', icon: 'fa-sign-out mr-2' }
  ];

  constructor() { }

  ngOnInit() {
  }

}
