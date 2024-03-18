import {ChangeDetectionStrategy, Component, OnDestroy, OnInit} from '@angular/core';
import {AuthService} from "./core/services/auth.service";
import {Subject, takeUntil} from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  changeDetection: ChangeDetectionStrategy.Default
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'docuware-frontend';
  isAuthenticated: boolean = false;
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.isAuthenticatedObservable().pipe(takeUntil(this.destroy$)).subscribe(isAuthenticated => {
      this.isAuthenticated = isAuthenticated;
    });
  }

  logout() {
    this.authService.logout();
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }
}
