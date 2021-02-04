import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UrlSerializer } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthenticationModule } from './authentication/authentication.module';
import { AppNotificationService, AuthorizeInterceptor } from './common/app.service';
import { AppComponent, ToastsContainer } from './app.component';
import { HomeComponent } from './home/home.component';
import { routing } from './app.routes';
import { LowerCaseUrlSerializer } from './common/app.util';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ToastsContainer
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AuthenticationModule,
    NgbModule,
    routing
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    //{ provide: UrlSerializer, useClass: LowerCaseUrlSerializer },
    AppNotificationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
