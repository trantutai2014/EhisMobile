import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { IonModal } from '@ionic/angular';
import { Subscription } from 'rxjs';
<<<<<<< HEAD
import { WebSocketService } from 'src/app/core/services/websocket.service';


=======
import { NotificationService } from 'src/app/core/services/notification.service';
import { WebSocketService } from 'src/app/core/services/websocket.service';

>>>>>>> bb5dda1161ca0cc37fcdda9b32550d38f0f96b3d

@Component({
  selector: 'app-thongbao',
  templateUrl: 'thong-bao.component.html',
})
export class ThongBaoComponent implements OnInit, OnDestroy {
  @ViewChild(IonModal) modal!: IonModal;
  messages: string[] = [];

  private subscription!: Subscription;

  constructor(
    private webSocketService: WebSocketService
  ) {}

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

  sendMessage(message: string) {
    this.webSocketService.sendMessage(message); // Send message to server
  }

  cancel() {
    this.modal.dismiss(null, 'cancel');
  }
}
