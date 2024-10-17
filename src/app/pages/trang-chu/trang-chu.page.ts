import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';

import { Subscription } from 'rxjs';

import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-main',
  templateUrl: './trang-chu.page.html',
  styleUrls: ['./trang-chu.page.scss'],
})
export class MainPage implements OnInit, OnDestroy {
  items: any;
  itemModel: any = {};
  loading: boolean = false;
  cccd: string | null | undefined;
  error: any;

  @ViewChild('swiperContainer') swiperContainer: any;
  username: string = '';
  private subscriptions: Subscription = new Subscription();

  autoplayConfig = {
    delay: 1000,
    disableOnInteraction: true
  };

  private apiUrl = `${environment.BASE_API}/api/ThongTin/`;
  constructor(private router: Router,  
    private route: ActivatedRoute,   
    private http: HttpClient) { }

  ngOnInit() {

    this.route.paramMap.subscribe(params => {
      this.cccd = params.get('cccd');
      if (this.cccd) {
        this.getUserInfo();
      } else {
        // Handle case where CCCD is not found in URL
        console.error('Không tìm thấy CCCD trong URL');
      }
    });


    setTimeout(() => {
      if (this.swiperContainer && this.swiperContainer.swiperRef) {
        const swiper = this.swiperContainer.swiperRef;
        swiper.update(); // Update Swiper to ensure images display correctly
      }
    }, 0);
  }

  //
  getUserInfo(): void {
    this.loading = true; // Set loading indicator to true
    this.http.get(`${this.apiUrl}${this.cccd}`).subscribe({
      next: (data:any) => {
        this.loading = false; // Set loading indicator to false
          this.items=data.data;
      },
      error: (error) => {
        this.loading = false; // Set loading indicator to false
        this.error = 'Failed to load user roles';
      }
    });
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
