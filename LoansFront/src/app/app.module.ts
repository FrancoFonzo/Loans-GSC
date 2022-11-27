import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/dashboard/home/home.component';
import { PeopleListComponent } from './components/dashboard/people/people-list/people-list.component';

import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './shared/shared.module';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { PersonCreateComponent } from './components/dashboard/people/person-create/person-create.component';
import { PersonDetailsComponent } from './components/dashboard/people/person-details/person-details.component';
import { PersonEditComponent } from './components/dashboard/people/person-edit/person-edit.component';
import { ErrorInterceptor } from './interceptors/error.interceptor';

export const AppComponents = [
  AppComponent,
  LoginComponent,
  HomeComponent,
  PeopleListComponent,
  PersonCreateComponent,
  PersonEditComponent,
  PersonDetailsComponent,
];

export const Modules = [
  BrowserModule,
  AppRoutingModule,
  HttpClientModule,
  ReactiveFormsModule,
  FormsModule,
  BrowserAnimationsModule,
  SharedModule
];

export const InterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
];

@NgModule({
  declarations: [
    AppComponents
  ],
  imports: [
    Modules
  ],
  providers: [
    InterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
