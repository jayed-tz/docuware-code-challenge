import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../../core/services/auth.service";
import {RegistrationService} from "../../../core/services/registration.service";
import {Subject, takeUntil} from "rxjs";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegistrationComponent implements OnInit, OnDestroy {
  eventId: string | null = null;
  registrationForm: FormGroup;
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private registrationService: RegistrationService, private snackBar: MatSnackBar) {
    this.registrationForm = this.fb.group({});
  }

  ngOnInit(): void {
    this.initializeForm();

    this.route.paramMap.subscribe(params => {
      this.eventId = params.get('id');
      console.log(this.eventId);
    });
  }

  initializeForm(): void {
    this.registrationForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.registrationForm.valid) {
      const registrationData = {...this.registrationForm.value, eventId: this.eventId};
      console.log(registrationData);
      this.registrationService.register(registrationData)
        .pipe(takeUntil(this.destroy$))
        .subscribe({
          next: (response) => {
            this.registrationForm.reset();
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
