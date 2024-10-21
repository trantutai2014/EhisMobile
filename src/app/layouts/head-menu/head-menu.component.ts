import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';

import { Subscription } from 'rxjs';
import { WebSocketService } from 'src/app/core/services/websocket.service';
import { IonModal } from '@ionic/angular';

@Component({
  selector: 'app-head-menu',
  templateUrl: './head-menu.component.html',
  styleUrls: ['./head-menu.component.scss'],
})
export class HeadMenuComponent implements OnInit, OnDestroy {
  @ViewChild('swiperContainer') swiperContainer: any;
  @ViewChild(IonModal) modal!: IonModal;
  username: string = '';
  private subscriptions: Subscription = new Subscription();

  autoplayConfig = {
    delay: 1000,
    disableOnInteraction: true
  };
  messages: any;

  constructor(private router: Router,private webSocketService: WebSocketService) { }

  ngOnInit() {
    
        this.messages = [];
        // Subscribe to WebSocket messages
        this.subscriptions = this.webSocketService.connect().subscribe(
          (message: string) => {
            this.messages.push(message); // Add message to the list
          },
          (error) => {
            console.error('WebSocket error:', error);
          }
        );
    setTimeout(() => {
      if (this.swiperContainer && this.swiperContainer.swiperRef) {
        const swiper = this.swiperContainer.swiperRef;
        swiper.update(); // Update Swiper to ensure images display correctly
      }
    }, 0);
  }
  sendMessage(message: string) {
    this.webSocketService.sendMessage(message); // Send message to server
  }

  cancel() {
    this.modal.dismiss(null, 'cancel');
  }

  ngOnDestroy() {
    if (this.subscriptions) {
      this.subscriptions.unsubscribe();
    }
    this.webSocketService.disconnect(); // Disconnect WebSocket
    this.subscriptions.unsubscribe();
  }
  // ... rest of your navigation methods

  goToThuoc() {
    this.router.navigate([UrlConstants.THONGTINTIEMCHUNG]);
  }

  goToBill() {
    this.router.navigate([UrlConstants.BILL]);
  }

  goToProFile() {
    this.router.navigate([UrlConstants.THONGTINHANHCHINH]);
  }

  goToMain() {
    this.router.navigate([UrlConstants.TRANGCHU]);
  }

  goToSetting() {
    this.router.navigate([UrlConstants.SETTING]);
  }

  goToHotLine() {
    this.router.navigate([UrlConstants.HOTLINE]);
  }

  goToHistory() {
    this.router.navigate([UrlConstants.LICHSU]);
  }

  goToDV() {
    this.router.navigate([UrlConstants.DICHVU]);
  }

  goToBenhAn() {
    this.router.navigate([UrlConstants.BENHAN]);
  }

  goToDotKham() {
    this.router.navigate([UrlConstants.DSDOTKHAMCHUABENH]);
  }

  goToBHYT() {
    this.router.navigate([UrlConstants.THONGTINBHYT]);
  }
}
