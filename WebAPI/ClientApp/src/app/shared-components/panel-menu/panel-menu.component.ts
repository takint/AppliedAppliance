import { Component, Input, OnInit } from '@angular/core';
import { MenuItem } from '../../common/models/menu-model';

@Component({
  selector: 'app-panel-menu',
  templateUrl: './panel-menu.component.html',
  styleUrls: ['./panel-menu.component.scss']
})
export class PanelMenuComponent {
  isExpanded = false;
  isIconExpanded = false;

  @Input() menuItems: Array<MenuItem>;

  toggle() {
    this.isExpanded = !this.isExpanded;
    this.isIconExpanded = !this.isIconExpanded;
  }

  constructor() { }

}
