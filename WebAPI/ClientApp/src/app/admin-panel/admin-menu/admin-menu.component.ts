import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-menu',
  templateUrl: './admin-menu.component.html',
  styleUrls: ['./admin-menu.component.scss']
})
export class AdminMenuComponent {
  isExpanded = false;
  menuItems: Array<MenuItem> = [
    { title: 'Schools', url: 'Schools', icon: 'fas fa-university' },
    { title: 'Students', url: 'Students', icon: 'fas fa-user-graduate' },
    { title: 'Agents', url: 'Agents', icon: 'fas fa-user-tie' },
    { title: 'School Requests', url: 'SchoolRequests', icon: 'fas fa-user-tie' },
  ];

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}

export interface MenuItem {
  title: string;
  url: string;
  icon: string;
}
