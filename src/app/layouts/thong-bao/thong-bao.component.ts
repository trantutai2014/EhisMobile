import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { IonModal, ModalController } from '@ionic/angular';
import { OverlayEventDetail } from '@ionic/core/components';
import { Subscription } from 'rxjs';
import { NotificationService } from 'src/app/core/services/notification.service';

@Component({
  selector: 'app-thongbao',
  templateUrl: 'thong-bao.component.html',
})
export class ThongBaoComponent implements OnInit, OnDestroy {
  @ViewChild(IonModal)
  modal!: IonModal;
  messages: string[] = [];

  subscription: Subscription | undefined;



  constructor(

    private notificationService: NotificationService,

    private modalController: ModalController

  ) { }
  ngOnInit() {

    // this.subscription = this.notificationService.connect()

    //   .subscribe((message: string) => {

    //     this.messages.push(message);

    //   });

  }

  ngOnDestroy() {

    if (this.subscription) {

      this.subscription.unsubscribe();

    }

    this.notificationService.closeConnection();

  }

  cancel() {
    this.modal.dismiss(null, 'cancel');
  }
}