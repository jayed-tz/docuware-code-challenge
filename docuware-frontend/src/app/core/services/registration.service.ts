import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import {of, Observable, tap} from 'rxjs';
import { Event } from '../../models/event.model';
import {environment} from "../../../environment";
import {Registration} from "../../models/registration.model";

@Injectable({ providedIn: 'root' })
export class RegistrationService {
  constructor(private http: HttpClient) {}

  register(registration: Registration): Observable<Registration> {
    return this.http
      .post<Registration>(
          `${environment.apiUrl}/registrations/create`,
        registration
      )
      .pipe();
  }

  getRegistrations(eventId: string): Observable<Array<Registration>> {
    return this.http
      .get<Registration[]>(
        `${environment.apiUrl}/registrations?eventid=${eventId}`
      )
      .pipe();
  }
}
