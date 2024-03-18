import {Component, OnDestroy, OnInit} from '@angular/core';
import {EventService} from "../../../core/services/event.service";
import {Event} from "../../../models/event.model";
import {Subject, takeUntil} from "rxjs";
import {AuthService} from "../../../core/services/auth.service";

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.scss'
})
export class EventListComponent implements OnInit, OnDestroy{
  eventList: Event[] = [];
  destroy$: Subject<boolean> = new Subject<boolean>();
  isAuthenticated: boolean = false;
  constructor(private eventService: EventService, private authService: AuthService) {
  }

  ngOnInit() {
    this.authService.isAuthenticatedObservable()
      .pipe(takeUntil(this.destroy$))
      .subscribe(isAuthenticated => {
        this.isAuthenticated = isAuthenticated;
      });

    this.eventService
      .getEvents()
      .pipe(takeUntil(this.destroy$))
      .subscribe((events) =>
        this.eventList = events
      );
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }
}
