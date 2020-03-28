import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogonComponent } from './pages/logon/logon.component';
import { RegisterComponent } from './pages/register/register.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { NewIncidentComponent } from './pages/new-incident/new-incident.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth/auth.interceptor';

import { LOCALE_ID } from '@angular/core';
import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { AuthGuard } from './auth/auth.guard';

registerLocaleData(localePt, 'pt');

@NgModule({
  declarations: [
    AppComponent,
    LogonComponent,
    RegisterComponent,
    ProfileComponent,
    NewIncidentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    {
      provide: LOCALE_ID,
      useValue: 'pt'
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
