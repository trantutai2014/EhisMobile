// import { HTTP_INTERCEPTORS, HttpEvent, HttpErrorResponse } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
// import { BehaviorSubject, Observable, throwError } from 'rxjs';
// import { catchError, filter, switchMap, take } from 'rxjs/operators';
// import { LoginService } from '../services/login.service';
// const TOKEN_HEADER_KEY = 'Authorization'; 

// @Injectable()
// export class AuthInterceptor implements HttpInterceptor {
//     private isRefreshing = false;
//     private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

//     constructor(private authService: LoginService) { }

//     intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<Object>> {
//         let authReq = req;
//         const token = this.authService.getLoggedInUser();
//         if (token != null) {
//             authReq = this.addTokenHeader(req, token.token);
//         }
//         return next.handle(authReq).pipe(catchError((error: any) => {
//             if (error instanceof HttpErrorResponse && error.status === 401) {
//                 return this.handle401Error(authReq, next);
//             }
//             return throwError(error);
//         }));
//     }

//     private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
//         if (!this.isRefreshing) {
//             this.isRefreshing = true;
//             this.refreshTokenSubject.next(null);

//             const token = this.authService.getLoggedInUser();
//             if (token)
//                 return this.authService.refreshToken(token.refreshToken).pipe(
//                     switchMap((token: any) => {
//                         this.isRefreshing = false;

//                         this.authService.saveToken(token);
//                         this.refreshTokenSubject.next(token.accessToken);

//                         return next.handle(this.addTokenHeader(request, token.token));
//                     }),
//                     catchError((err) => {
//                         this.isRefreshing = false;

//                         this.authService.logout();
//                         return throwError(err);
//                     })
//                 );
//         }

//         return this.refreshTokenSubject.pipe(
//             filter(token => token !== null),
//             take(1),
//             switchMap((token) => next.handle(this.addTokenHeader(request, token)))
//         );
//     }

//     private addTokenHeader(request: HttpRequest<any>, token: string) {
//         return request.clone({ headers: request.headers.set(TOKEN_HEADER_KEY, "Bearer " + token) });
//     }
// }