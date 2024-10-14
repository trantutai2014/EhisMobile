import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { NotificationService } from 'src/app/core/services/notification.service';

@Component({
  selector: 'app-gui-thong-bao',
  templateUrl: 'gui-thong-bao.component.html',
})
export class GuiThongBaoComponent implements OnInit, OnDestroy {
  message: string = '';
  subscription: Subscription | undefined;

  constructor(private notificationService: NotificationService) {}

  ngOnInit() {}

  sendNotification() {
    this.notificationService.sendMessage(this.message);
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}