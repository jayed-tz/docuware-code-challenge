import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { of, Observable } from 'rxjs';
import { Event } from '../../models/event.model';
import {environment} from "../../../environment";
import {Registration} from "../../models/registration.model";

@Injectable({ providedIn: 'root' })
export class EventService {
  constructor(private http: HttpClient) {}

  getEvents(): Observable<Array<Event>> {
    return this.http
      .get<Event[]>(
          `${environment.apiUrl}/events`
      )
      .pipe();
  }

  create(event: Event): Observable<Event> {
    return this.http
        .post<Event>(
            `${environment.apiUrl}/events/create`,
            event
        )
        .pipe();
  }
}
