import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AdminPanelComponent } from './admin-panel.component';
import { PanelHeaderComponent } from './panel-header/panel-header.component';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedComponentsModule } from '../shared-components/shared-components.module';

const ADMIN_PANEL_ROUTE = [
  {
    path: '', component: AdminPanelComponent, children: [
      { path: '', redirectTo: 'Dashboard', pathMatch: 'full' },
      { path: 'Dashboard', component: DashboardComponent },
      { path: 'Schools', loadChildren: () => import('./schools/schools.module').then(m => m.SchoolsModule) },
      { path: 'Agents', loadChildren: () => import('./agents/agents.module').then(m => m.AgentsModule) },
      { path: 'Students', loadChildren: () => import('./students/students.module').then(m => m.StudentsModule) }
    ]
  },
];


@NgModule({

  declarations: [
    DashboardComponent,
    AdminPanelComponent,
    PanelHeaderComponent,
    AdminMenuComponent
  ],

  imports: [
    CommonModule,
    NgbModule,
    SharedComponentsModule,
    RouterModule.forChild(ADMIN_PANEL_ROUTE),
  ],

  providers: [
    NgbActiveModal
  ]
})
export class AdminPanelModule { }
