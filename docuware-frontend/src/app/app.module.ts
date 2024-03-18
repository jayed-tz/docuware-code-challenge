import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventListComponent } from './pages/event/event-list/event-list.component';
import { CreateRegistrationComponent } from './pages/registration/create-registration/create-registration.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { LoginComponent } from './pages/login/login.component';
import {ReactiveFormsModule} from "@angular/forms";
import {AuthInterceptor} from "./core/services/authInterceptor";
import {AuthGuard} from "./gurads/authGuard";
import {MatCard, MatCardActions, MatCardContent, MatCardTitle} from "@angular/material/card";
import {MatList, MatListItem} from "@angular/material/list";
import {MatLine} from "@angular/material/core";
import {MatAnchor, MatButton} from "@angular/material/button";
import {MatToolbar} from "@angular/material/toolbar";
import {MatError, MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { RegistrationListComponent } from './pages/registration/registration-list/registration-list.component';
import { CreateEventComponent } from './pages/event/create-event/create-event.component';

@NgModule({
  declarations: [
    AppComponent,
    EventListComponent,
    CreateRegistrationComponent,
    LoginComponent,
    RegistrationListComponent,
    CreateEventComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatCard,
    MatCardTitle,
    MatCardContent,
    MatList,
    MatListItem,
    MatLine,
    MatButton,
    MatCardActions,
    MatToolbar,
    MatAnchor,
    MatFormField,
    MatInput,
    MatError,
    MatLabel
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
