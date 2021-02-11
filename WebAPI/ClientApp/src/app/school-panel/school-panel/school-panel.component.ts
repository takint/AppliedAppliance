import { Component, OnInit } from '@angular/core';
import { MenuItem } from '../../common/models/menu-model';

@Component({
  selector: 'app-school-panel',
  templateUrl: './school-panel.component.html',
  styleUrls: ['./school-panel.component.scss']
})
export class SchoolPanelComponent implements OnInit {

  schoolMenuItems: Array<MenuItem> = [
    { title: 'Schools Details', url: 'details', icon: 'fas fa-lg fa-university mr-2' },
    { title: 'Campuses', url: 'campuses', icon: 'fas fa-lg fa-user-graduate mr-2' },
    { title: 'Programs', url: 'programs', icon: 'fas fa-lg fa-file-alt mr-2' },
    { title: 'Program Categories', url: 'program-categories', icon: 'fas fa-lg fa-user-tie mr-2' },
    { title: 'Start Date', url: 'start-dates', icon: 'fas fa-lg fa-folder-open mr-2' },
    { title: 'Applications', url: 'applications', icon: 'fas fa-lg fa-list-ul mr-2' },
    { title: 'Users', url: 'users', icon: 'fas fa-lg fa-address-book mr-2' },
    { title: 'Documents', url: 'documents', icon: 'fas fa-lg fa-users mr-2' },
    { title: 'PandaDoc Template', url: 'panda-doc-template', icon: 'fas fa-lg fa-user-shield mr-2' },
    { title: 'Payments', url: 'payments', icon: 'fas fa-lg fa-user-shield mr-2' },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
