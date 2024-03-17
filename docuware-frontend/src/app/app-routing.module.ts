import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {EventComponent} from "./pages/event/container/event.component";
import {RegistrationComponent} from "./pages/registration/container/registration.component";

const routes: Routes = [
  {path: 'event', component: EventComponent},
  {path: 'registration', component: RegistrationComponent},
  {path: '', redirectTo: 'event', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
