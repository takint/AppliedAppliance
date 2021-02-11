import { Component, OnInit } from '@angular/core';
import { MenuItem } from '../common/models/menu-model';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {

  adminMenuItems: Array<MenuItem> = [
    { title: 'Schools', url: 'schools', icon: 'fas fa-lg fa-university mr-2' },
    { title: 'Students', url: 'students', icon: 'fas fa-lg fa-user-graduate mr-2' },
    { title: 'Applications', url: 'applications', icon: 'fas fa-lg fa-file-alt mr-2' },
    { title: 'Agents', url: 'agents', icon: 'fas fa-lg fa-user-tie mr-2' },
    { title: 'Documents', url: 'documents', icon: 'fas fa-lg fa-folder-open mr-2' },
    { title: 'Program Categories', url: 'program-categories', icon: 'fas fa-lg fa-list-ul mr-2' },
    { title: 'School Requests', url: 'schoolRequests', icon: 'fas fa-lg fa-address-book mr-2' },
    { title: 'Users Management', url: 'users', icon: 'fas fa-lg fa-users mr-2' },
    { title: 'Roles Management', url: 'roles', icon: 'fas fa-lg fa-user-shield mr-2' },
  ];

  constructor() { }

  ngOnInit() {
  }

}
