import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { IonModal } from '@ionic/angular';
import { Subscription } from 'rxjs';
import { WebSocketService } from 'src/app/core/services/websocket.service';

@Component({
  selector: 'app-thongbao',
  templateUrl: 'thong-bao.component.html',
})
export class ThongBaoComponent implements OnInit, OnDestroy {
  @ViewChild(IonModal) modal!: IonModal;
  messages: string[] = [];

  private subscription!: Subscription;

  constructor(private webSocketService: WebSocketService) {}

  ngOnInit() {
    // Subscribe to WebSocket messages
    this.subscription = this.webSocketService.connect().subscribe(
      (message: string) => {
        this.messages.push(message); // Add message to the list
      },
      (error) => {
        console.error('WebSocket error:', error);
      }
    );
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
    this.webSocketService.disconnect(); // Disconnect WebSocket
  }

  // Function to clear all notifications
  clearNotifications() {
    this.messages = []; // Clear the messages array
  }

  // Function to close the modal
  cancel() {
    this.modal.dismiss(null, 'cancel');
  }
}
