import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ApplicationPaths } from '../common/app.constants';
import { LogoutComponent } from './logout/logout.component';



@NgModule({
  declarations: [LoginComponent, LogoutComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule.forChild(
      [
        { path: ApplicationPaths.Register, component: LoginComponent },
        { path: ApplicationPaths.Profile, component: LoginComponent },
        { path: ApplicationPaths.Login, component: LoginComponent },
        { path: ApplicationPaths.LoginFailed, component: LoginComponent },
        { path: ApplicationPaths.LoginCallback, component: LoginComponent },
        //{ path: ApplicationPaths.LogOut, component: LogoutComponent },
        //{ path: ApplicationPaths.LoggedOut, component: LogoutComponent },
        //{ path: ApplicationPaths.LogOutCallback, component: LogoutComponent }
      ]
    )
  ],
  exports: [LoginComponent]
})
export class AuthenticationModule { }
