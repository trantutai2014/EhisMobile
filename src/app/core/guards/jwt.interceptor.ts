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
        // Handle 401 Unauthorized errors
        if (error.status === 401) {
          return this.handle401Error(request, next);
        }
        return throwError(() => error);
      })
    );
  }

  // Add JWT token to headers
  private addToken(request: HttpRequest<any>, token: string) {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });
  }

  // Handle 401 error by trying to refresh token
  private handle401Error(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!this.authService.isRefreshTokenInProgress()) {
      this.authService.setRefreshTokenInProgress(true);
      this.authService.getAccessTokenSubject().next(null); // Clear current access token

      // Call the refresh token API
      return this.authService.refreshToken().pipe(
        switchMap((newToken: any) => {
          this.authService.setRefreshTokenInProgress(false);
          this.authService.getAccessTokenSubject().next(newToken.accessToken); // Set new access token
          return next.handle(this.addToken(request, newToken.accessToken)); // Retry the original request with new token
        }),
        catchError((err) => {
          this.authService.setRefreshTokenInProgress(false);
          return throwError(() => err); // If refresh fails, forward the error
        })
      );
    } else {
      // If refresh token is already in progress, wait until it's finished
      return this.authService.getAccessTokenSubject().pipe(
        filter(token => token !== null),
        take(1),
        switchMap((token) => {
          return next.handle(this.addToken(request, token!)); // Retry original request with new token
        })
      );
    }
  }
}
