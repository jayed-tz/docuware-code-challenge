import {Component, OnInit} from '@angular/core';
import {EventService} from "../../../../core/services/event.service";
import {Event} from "../../../../models/event.model";

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrl: './event-list.component.scss'
})
export class EventListComponent implements OnInit{
  eventList: Event[] = [];
  constructor(private eventService: EventService) {
  }

  ngOnInit() {
    this.eventService
      .getEvents()
      .subscribe((events) =>
        this.eventList = events
      );
  }
}
