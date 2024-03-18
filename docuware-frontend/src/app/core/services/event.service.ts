import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { of, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Event } from '../../models/event.model';

@Injectable({ providedIn: 'root' })
export class EventService {
  constructor(private http: HttpClient) {}

  getEvents(): Observable<Array<Event>> {
    return this.http
      .get<Event[]>(
        'https://localhost:7150/events' // TODO: config
      )
      .pipe();
  }
}
