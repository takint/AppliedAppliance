import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AdminPanelComponent } from './admin-panel.component';
import { PanelHeaderComponent } from './panel-header/panel-header.component';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';


const ADMIN_PANEL_ROUTE = [
  {
    path: '', component: AdminPanelComponent, children: [
      { path: '', redirectTo: 'Dashboard', pathMatch: 'full' },
      { path: 'Dashboard', component: DashboardComponent },
      { path: 'Schools', loadChildren: './schools/schools.module#SchoolsModule' },
      { path: 'Agents', loadChildren: './agents/agents.module#AgentsModule' },
      { path: 'Students', loadChildren: './students/students.module#StudentsModule' }
    ]
  },
];


@NgModule({
  declarations: [DashboardComponent, AdminPanelComponent, PanelHeaderComponent, AdminMenuComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(ADMIN_PANEL_ROUTE)
  ]
})
export class AdminPanelModule { }
