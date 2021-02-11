import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { take } from 'rxjs/operators';
import { ApplicationPaths, LogoutActions } from '../../common/app.constants';
import { AuthenticationResultStatus, AuthService, INavigationState } from '../../common/auth.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {

  public message = new BehaviorSubject<string>(null);

  constructor(
    private authorizeService: AuthService,
    private activatedRoute: ActivatedRoute,
    private router: Router) { }

  async ngOnInit() {
    const action = this.activatedRoute.snapshot.url[1];
    switch (action.path) {
      case LogoutActions.Logout:
        if (!!window.history.state.local) {
          await this.logout(this.getReturnUrl());
        } else {
          this.message.next('The logout was not initiated from within the page.');
        }
        break;
      case LogoutActions.LogoutCallback:
        await this.processLogoutCallback();
        break;
      case LogoutActions.LoggedOut:
        window.location.href = '/';
        break;
      default:
        throw new Error(`Invalid action '${action}'`);
    }
  }

  private async navigateToReturnUrl(returnUrl: string) {
    await this.router.navigateByUrl(returnUrl, {
      replaceUrl: true
    });
  }

  private async logout(returnUrl: string): Promise<void> {
    const state: INavigationState = { returnUrl };
    const isauthenticated = await this.authorizeService.isAuthenticated().pipe(
      take(1)
    ).toPromise();
    if (isauthenticated) {
      const result = await this.authorizeService.signOut(state);
      switch (result.status) {
        case AuthenticationResultStatus.Redirect:
          break;
        case AuthenticationResultStatus.Success:
          await this.navigateToReturnUrl(returnUrl);
          break;
        case AuthenticationResultStatus.Fail:
          this.message.next(result.message);
          break;
        default:
          throw new Error('Invalid authentication result status.');
      }
    } else {
      this.message.next('You successfully logged out!');
    }
  }

  private async processLogoutCallback(): Promise<void> {
    const url = window.location.href;
    const result = await this.authorizeService.completeSignOut(url);
    switch (result.status) {
      case AuthenticationResultStatus.Redirect:
        throw new Error('Should not redirect.');
      case AuthenticationResultStatus.Success:
        await this.navigateToReturnUrl(this.getReturnUrl(result.state));
        break;
      case AuthenticationResultStatus.Fail:
        this.message.next(result.message);
        break;
      default:
        throw new Error('Invalid authentication result status.');
    }
  }

  private getReturnUrl(state?: INavigationState): string {
    const fromQuery = (this.activatedRoute.snapshot.queryParams as INavigationState).returnUrl;
    if (fromQuery &&
      !(fromQuery.startsWith(`${window.location.origin}/`) ||
        /\/[^\/].*/.test(fromQuery))) {
      throw new Error('Invalid return url. The return url needs to have the same origin as the current page.');
    }
    return (state && state.returnUrl) ||
      fromQuery ||
      ApplicationPaths.LoggedOut;
  }

}
