import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent, ToastsContainer } from './app.component';
import { HomeComponent } from './home/home.component';

import { routing } from './app.routes';
import { AppNotificationService } from './common/app.service';

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
    NgbModule,
    routing
  ],
  providers: [AppNotificationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
