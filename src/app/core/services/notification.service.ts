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
  connect() {
    throw new Error('Method not implemented.');
  }
  closeConnection() {
    throw new Error('Method not implemented.');
  }
  private notifyRequest = new ReplaySubject<Notification>();
  notifyRequest$ = this.notifyRequest.asObservable();

  constructor() {}

  notify(notification: Notification) {
    this.notifyRequest.next(notification);
  }
}
