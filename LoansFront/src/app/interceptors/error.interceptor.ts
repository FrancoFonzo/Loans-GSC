import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { NotificationService } from '../services/notification.service';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService,
     private notification: NotificationService, private router: Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error) => {
        if (error instanceof HttpErrorResponse) {
          switch (error.status) {
            case 400:
              this.notification.showError("The server could not understand the request due to invalid syntax.");
              break;
            case 401:
              this.notification.showError(error.error.message);
              break;
            case 403:
              this.notification.showError("You are not authorized to perform this action.");
              break;
            case 404:
              this.router.navigate(['']).then((navigated: boolean) => {
                if(navigated) this.notification.showError(error.error);
              });
              break;
            case 409:
              this.notification.showError(error.error);
              break;
            case 500:
              this.notification.showError("There was an error on the server. Please try again later.");
              break;
            default:
              this.notification.showError("Uh oh! Something went wrong. Try again later.");
              break;
          }
        }
        return throwError(() => error);
      })
    );
  }
}
