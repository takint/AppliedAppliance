import { Routes, RouterModule } from '@angular/router';
import { ApplicationPaths } from './common/app.constants';
import { AuthorizeGuard } from './common/auth.service';
import { ErrorsComponent } from './errors/errors.component';

const BASE_ROUTES: Routes = [
  { path: '', redirectTo: ApplicationPaths.Login, pathMatch: 'full' },
  { path: 'admin', loadChildren: () => import('./admin-panel/admin-panel.module').then(m => m.AdminPanelModule), canActivate: [AuthorizeGuard] },
  //{ path: 'agent', loadChildren: './admin-panel/admin-panel.module#AdminPanelModule' },
  { path: 'school', loadChildren: () => import('./school-panel/school-panel.module').then(m => m.SchoolPanelModule), canActivate: [AuthorizeGuard] },
  //{ path: 'student', loadChildren: './admin-panel/admin-panel.module#AdminPanelModule' }
  { path: '**', component: ErrorsComponent }
];

export const routing = RouterModule.forRoot(BASE_ROUTES, { relativeLinkResolution: 'legacy' });
