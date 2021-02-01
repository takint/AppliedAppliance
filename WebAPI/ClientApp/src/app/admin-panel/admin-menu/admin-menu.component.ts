import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-menu',
  templateUrl: './admin-menu.component.html',
  styleUrls: ['./admin-menu.component.scss']
})
export class AdminMenuComponent {
  isExpanded = false;
  isIconExpanded = false;

  menuItems: Array<MenuItem> = [
    { title: 'Schools', url: 'Schools', icon: 'fas fa-lg fa-university mr-2' },
    { title: 'Students', url: 'Students', icon: 'fas fa-lg fa-user-graduate mr-2' },
    { title: 'Applications', url: 'Applications', icon: 'fas fa-lg fa-file-alt mr-2' },
    { title: 'Agents', url: 'Agents', icon: 'fas fa-lg fa-user-tie mr-2' },
    { title: 'Documents', url: 'Documents', icon: 'fas fa-lg fa-folder-open mr-2' },
    { title: 'Program Categories', url: 'ProgramCategories', icon: 'fas fa-lg fa-list-ul mr-2' },
    { title: 'School Requests', url: 'SchoolRequests', icon: 'fas fa-lg fa-address-book mr-2' },
    { title: 'Users Management', url: 'SchoolUsers', icon: 'fas fa-lg fa-users mr-2' },
    { title: 'Roles Management', url: 'SchoolUsers', icon: 'fas fa-lg fa-user-shield mr-2' },
  ];

  toggle() {
    this.isExpanded = !this.isExpanded;
    this.isIconExpanded = !this.isIconExpanded;
  }
}

export interface MenuItem {
  title: string;
  url: string;
  icon: string;
}
