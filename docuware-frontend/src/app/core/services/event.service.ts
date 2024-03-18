import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { of, Observable } from 'rxjs';
import { Event } from '../../models/event.model';
import {environment} from "../../../environment";

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
}
