import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import {of, Observable, catchError, tap, BehaviorSubject} from 'rxjs';
import {Router} from "@angular/router";
import {environment} from "../../../environment";

@Injectable({ providedIn: 'root' })
export class AuthService {
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(this.isAuthenticated());

  constructor(private http: HttpClient, private router: Router) {
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('authToken');
  }

  isAuthenticatedObservable(): Observable<boolean> {
    return this.isAuthenticatedSubject.asObservable();
  }

  setAuthenticatedStatus(isAuthenticated: boolean): void {
    this.isAuthenticatedSubject.next(isAuthenticated);
  }

  logout() {
    localStorage.removeItem('authToken');
    this.setAuthenticatedStatus(false);
    this.router.navigate(['/login']);
  }
  getToken(username: string, password: string): Observable<string> {
    return this.http
      .post(
        `${environment.apiUrl}/identity/token`,
         {
          username,
          password,
        },{
          responseType: 'text', // Set response type to text
        })
      .pipe(
        tap(token => {
          // Store the token securely in local storage
          localStorage.setItem('authToken', token);
          this.setAuthenticatedStatus(true);
        })
      );
  }
}
