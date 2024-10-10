import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NotificationService } from '../services/notification.service';


export enum NotificationType {
  Success = 'is-success',
  Danger = 'is-danger',
  Warning = 'is-warning',
}

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
  constructor(private notificationService: NotificationService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Kiểm tra trạng thái kết nối (ví dụ: kiểm tra kết nối internet)
    if (!this.notificationService.isConnected()) {
      // Xử lý khi không có kết nối
      this.notificationService.notify({
        title: 'Lỗi kết nối',
        message: 'Vui lòng kiểm tra kết nối mạng của bạn',
        type: NotificationType.Danger // Đây là cách truy cập đúng
      });
      return throwError('No connection');
    }

    // Thêm các logic khác như:
    // - Thêm token xác thực vào header
    // - Hiển thị loading
    // ...

    return next.handle(request);
  }
}