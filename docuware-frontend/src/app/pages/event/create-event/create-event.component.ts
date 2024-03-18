import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Subject, takeUntil} from "rxjs";
import {ActivatedRoute} from "@angular/router";
import {RegistrationService} from "../../../core/services/registration.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {EventService} from "../../../core/services/event.service";

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrl: './create-event.component.scss'
})
export class CreateEventComponent implements OnInit, OnDestroy {
  eventForm: FormGroup;
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private eventService: EventService, private snackBar: MatSnackBar) {
    this.eventForm = this.fb.group({});
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(): void {
    this.eventForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', [Validators.required]],
      location: ['', Validators.required],
      startTime: ['', Validators.required],
      duration: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.eventForm.valid) {
      const eventData = {...this.eventForm.value};
      this.eventService.create(eventData)
        .pipe(takeUntil(this.destroy$))
        .subscribe({
          next: (response) => {
            this.eventForm.reset();
            this.snackBar.open('Registration Successful!', 'Dismiss', {
              duration: 3000,
            });

          },
          error: (error) => {
            console.error(error);
          }
        });
    } else {
      console.error('Form is invalid');
    }
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }
}
