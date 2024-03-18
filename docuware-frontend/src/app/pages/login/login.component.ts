import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../core/services/auth.service";
import {Router} from "@angular/router";
import {Subject, takeUntil} from "rxjs";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.loginForm = this.fb.group({});
  }

  ngOnInit() {
    this.authService.isAuthenticatedObservable()
      .pipe(takeUntil(this.destroy$))
      .subscribe(isAuthenticated => {
      if (isAuthenticated) {
        this.navigateAway();
      }
    });

    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const username = this.loginForm.value.username;
      const password = this.loginForm.value.password;

      this.authService.getToken(username, password)
        .subscribe(token => {
          this.navigateAway();
      });
    } else {
      console.error('Form is invalid');
    }
  }

  private navigateAway() {
    this.router.navigate(['/event']);
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }
}
