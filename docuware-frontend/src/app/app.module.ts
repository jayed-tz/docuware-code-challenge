import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventListComponent } from './pages/event/components/event-list/event-list.component';
import { EventComponent } from './pages/event/container/event.component';
import { RegistrationListComponent } from './pages/registration/components/registration-list/registration-list.component';
import { RegistrationComponent } from './pages/registration/container/registration.component';

@NgModule({
  declarations: [
    AppComponent,
    EventListComponent,
    EventComponent,
    RegistrationListComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
