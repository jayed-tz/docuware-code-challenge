import {Component, OnDestroy, OnInit} from '@angular/core';
import {Event} from "../../../models/event.model";
import {Subject, takeUntil} from "rxjs";
import {EventService} from "../../../core/services/event.service";
import {Registration} from "../../../models/registration.model";
import {RegistrationService} from "../../../core/services/registration.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-registration-list',
  templateUrl: './registration-list.component.html',
  styleUrl: './registration-list.component.scss'
})
export class RegistrationListComponent implements OnInit, OnDestroy{
  registrationList: Registration[] = [];
  destroy$: Subject<boolean> = new Subject<boolean>();
  constructor(private registrationService: RegistrationService, private route: ActivatedRoute,) {
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.registrationService
        .getRegistrations(params.get('id')!)
        .pipe(takeUntil(this.destroy$))
        .subscribe((registrations) =>
          this.registrationList = registrations
        );
    });
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }
}
