import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { AuthRequest } from '../interfaces/authRequest';
import { AuthResponse } from '../interfaces/authResponse';
import { NotificationService } from './notification.service';

const URL = `${environment.apiUrl}/auth/login`;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private notification: NotificationService) { }

  public login(authRequest: AuthRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(URL, authRequest)
      .pipe(map((authResponse: AuthResponse) => {
        this.saveToken(authResponse.token);
        return authResponse;
      }));
  }

  public logout(): void {
    localStorage.removeItem("authToken");
    window.location.reload();
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  saveToken(token: string): void {
    localStorage.setItem("authToken", token);
  }

  getToken(): string | null {
    return localStorage.getItem("authToken");
  }
  
}
