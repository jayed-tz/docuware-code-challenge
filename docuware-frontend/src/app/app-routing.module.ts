import {inject, NgModule} from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {CreateRegistrationComponent} from "./pages/registration/create-registration/create-registration.component";
import {LoginComponent} from "./pages/login/login.component";
import {AuthGuard} from "./gurads/authGuard";
import {EventListComponent} from "./pages/event/event-list/event-list.component";
import {RegistrationListComponent} from "./pages/registration/registration-list/registration-list.component";
import {CreateEventComponent} from "./pages/event/create-event/create-event.component";

const routes: Routes = [
  {path: 'event', component: EventListComponent},
  {path: 'create-event', component: CreateEventComponent},
  {path: 'registration/:id', component: CreateRegistrationComponent},
  {path: 'registration-list/:id', component: RegistrationListComponent},
  {path: 'login', component: LoginComponent},
  { path: '**', redirectTo: 'event' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
