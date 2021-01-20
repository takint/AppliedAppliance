import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

const BASE_ROUTES: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'Admin', loadChildren: './admin-panel/admin-panel.module#AdminPanelModule' },
  //{ path: 'agent', loadChildren: './admin-panel/admin-panel.module#AdminPanelModule' },
  //{ path: 'school', loadChildren: './admin-panel/admin-panel.module#AdminPanelModule' },
  //{ path: 'student', loadChildren: './admin-panel/admin-panel.module#AdminPanelModule' },
];

export const routing = RouterModule.forRoot(BASE_ROUTES);
