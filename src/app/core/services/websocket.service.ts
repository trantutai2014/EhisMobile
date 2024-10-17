import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})
export class WebSocketService {
  private socket!: WebSocket;
  private messageSubject = new Subject<string>();
  public message$ = this.messageSubject.asObservable();

  constructor() {}

  connect(): Observable<string> {
    this.socket = new WebSocket('ws://192.168.0.110/api/Notification/ws');

    this.socket.onopen = () => {
      console.log('Connected to WebSocket server');
    };

    this.socket.onmessage = (event: MessageEvent) => {
      this.messageSubject.next(event.data);
    };

    this.socket.onclose = (event: CloseEvent) => {
      console.log('Disconnected from WebSocket server:', event.reason);
    };

    this.socket.onerror = (error: Event) => {
      console.error('WebSocket error:', error);
    };

    return this.message$;
  }

  sendMessage(message: string) {
    if (this.socket && this.socket.readyState === WebSocket.OPEN) {
      this.socket.send(message);
    } else {
      console.error('WebSocket is not open. Cannot send message.');
    }
  }

  disconnect() {
    if (this.socket) {
      this.socket.close();
    }
  }
}
