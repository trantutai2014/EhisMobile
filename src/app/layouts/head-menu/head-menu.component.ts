import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';

import { Subscription } from 'rxjs';

@Component({
  selector: 'app-head-menu',
  templateUrl: './head-menu.component.html',
  styleUrls: ['./head-menu.component.scss'],
})
export class HeadMenuComponent implements OnInit, OnDestroy {
  @ViewChild('swiperContainer') swiperContainer: any;
  username: string = '';
  private subscriptions: Subscription = new Subscription();

  autoplayConfig = {
    delay: 1000,
    disableOnInteraction: true
  };

  constructor(private router: Router) { }

  ngOnInit() {


    setTimeout(() => {
      if (this.swiperContainer && this.swiperContainer.swiperRef) {
        const swiper = this.swiperContainer.swiperRef;
        swiper.update(); // Update Swiper to ensure images display correctly
      }
    }, 0);
  }

  ngOnDestroy() {
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
