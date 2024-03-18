import {inject, NgModule} from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {EventComponent} from "./pages/event/container/event.component";
import {RegistrationComponent} from "./pages/registration/container/registration.component";
import {LoginComponent} from "./pages/login/login.component";
import {AuthGuard} from "./gurads/authGuard";

const routes: Routes = [
  {path: 'event', component: EventComponent},
  {path: 'admin-registration', component: RegistrationComponent, canActivate: [AuthGuard]},
  {path: 'login', component: LoginComponent},
  {path: '', redirectTo: 'event', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }