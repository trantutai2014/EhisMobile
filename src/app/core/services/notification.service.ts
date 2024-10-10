import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';

export enum NotificationType {
  Success = 'is-success',
  Danger = 'is-danger',
  Warning = 'is-warning',
}

export interface Notification {
  title: string;
  message: string;
  type: NotificationType;
}

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  public connected = false; // Flag for connection status
  private notifyRequest = new ReplaySubject<Notification>();
  notifyRequest$ = this.notifyRequest.asObservable();

  constructor() {}

  // Simulate connecting to an API (replace with your actual logic)
  connect() {
    this.connected = true;
    setTimeout(() => {
      console.log('Connected to API (simulated)');
    }, 1000); // Simulate delay
  }

  notify(notification: Notification) {
    if (this.connected) {
      this.notifyRequest.next(notification);
    } else {
      console.error('Cannot send notification - Not connected');
    }
  }
  isConnected(): boolean {
    // Thực hiện kiểm tra kết nối (ví dụ: sử dụng window.navigator.onLine)
    return navigator.onLine;
  }
}