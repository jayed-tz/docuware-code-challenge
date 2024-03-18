import {Component, OnDestroy, OnInit} from '@angular/core';
import {EventService} from "../../../../core/services/event.service";
import {Event} from "../../../../models/event.model";
import {Subject, takeUntil} from "rxjs";

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.scss'
})
export class EventListComponent implements OnInit, OnDestroy{
  eventList: Event[] = [];
  destroy$: Subject<boolean> = new Subject<boolean>();
  constructor(private eventService: EventService) {
  }

  ngOnInit() {
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
