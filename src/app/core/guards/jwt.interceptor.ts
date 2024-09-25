import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.authService.getToken(); // Lấy token từ AuthService

    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}` // Thêm token vào header
        }
      });
    }

    return next.handle(request); // Gửi yêu cầu tiếp theo
  }
}
