import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';


@Component({
  selector: 'app-main',
  templateUrl: './trang-chu.page.html',
  styleUrls: ['./trang-chu.page.scss'],
})
export class MainPage implements OnInit {
  @ViewChild('swiperContainer') swiperContainer: any;

  autoplayConfig = {
    delay: 1000,
    disableOnInteraction: true
  };

  swiperSlideChanged(e: any) {
    console.log('changed:', e)
  } 

  constructor(private router: Router) { }

  ngOnInit() {
    setTimeout(() => {
      const swiper = this.swiperContainer.swiperRef;
      swiper.update(); // Cập nhật Swiper để đảm bảo ảnh hiển thị đúng
    }, 0);
  }

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
}

