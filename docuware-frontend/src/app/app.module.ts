import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventListComponent } from './pages/event/components/event-list/event-list.component';
import { EventComponent } from './pages/event/container/event.component';
import { RegistrationListComponent } from './pages/registration/components/registration-list/registration-list.component';
import { RegistrationComponent } from './pages/registration/container/registration.component';
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

@NgModule({
  declarations: [
    AppComponent,
    EventListComponent,
    EventComponent,
    RegistrationListComponent,
    RegistrationComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
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
    MatAnchor
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
