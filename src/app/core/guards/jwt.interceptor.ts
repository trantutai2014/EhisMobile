import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { catchError, switchMap, filter, take } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.authService.getToken();

    if (token) {
      request = this.addToken(request, token);
    }

    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          // If the error status is 401, attempt to refresh the token
          return this.handle401Error(request, next);
        }
        return throwError(() => error);
      })
    );
  }

  private addToken(request: HttpRequest<any>, token: string) {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }

  private handle401Error(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!this.authService.isRefreshTokenInProgress()) {
      this.authService.setRefreshTokenInProgress(true);
      this.authService.getAccessTokenSubject().next(null);

      return this.authService.refreshToken().pipe(
        switchMap((newToken: any) => {
          this.authService.setRefreshTokenInProgress(false);
          this.authService.getAccessTokenSubject().next(newToken.accessToken);
          return next.handle(this.addToken(request, newToken.accessToken));
        }),
        catchError((err) => {
          this.authService.setRefreshTokenInProgress(false);
          this.authService.logout(); // Optional: Logout if refresh fails
          return throwError(() => err);
        })
      );
    } else {
      return this.authService.getAccessTokenSubject().pipe(
        filter(token => token !== null),
        take(1),
        switchMap((token) => next.handle(this.addToken(request, token!)))
      );
    }
  }
}
