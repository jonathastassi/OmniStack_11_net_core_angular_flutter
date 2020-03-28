import { SessionsService } from './../services/sessions.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private serviceSession: SessionsService
  ) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const ongId = localStorage.getItem('hero:ongId');
    if (ongId) {
      const authReq = request.clone({
        setHeaders: {
          Authorization: ongId
        }
      });
      return next.handle(authReq)
        .pipe(
          catchError(
            (err) => {
              if (err instanceof HttpErrorResponse) {
                if (err.status === 401 || err.status === 0) {
                  this.serviceSession.Logout();
                }
              }
              return throwError(err);
            }
          )
        )
    }
    return next.handle(request);
  }
}
