import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';

import { Subscription } from 'rxjs';
import { WebSocketService } from 'src/app/core/services/websocket.service';
import { IonModal } from '@ionic/angular';
import { environment } from 'src/environments/environment.prod';
import { HttpClient } from '@angular/common/http';

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
  private apiUrl = `${environment.BASE_API}/api/Notification/`;

  items: any;
  error: any;
  loading: boolean = false;

  autoplayConfig = {
    delay: 1000,
    disableOnInteraction: true
  };
  
  
  messages: { content: string; isRead: boolean }[] = [];
  unreadCount: number = 0;

  constructor(private router: Router,private webSocketService: WebSocketService,
    private http: HttpClient
  ) { }

  ngOnInit() {
this.getThongBaoByCccd();

    this.updateUnreadCount();

    this.subscriptions = this.webSocketService.connect().subscribe(
      (message: string) => {
        // Tạo đối tượng với thuộc tính content và isRead
        this.messages.push({ content: message, isRead: false });
        this.updateUnreadCount(); // Cập nhật số thông báo chưa đọc
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

  async getThongBaoByCccd(): Promise<void> {
    const cccd = localStorage.getItem('cccd');
    this.loading = true; // Set loading indicator to true
  
    try {
      const data: any = await this.http.get(`${this.apiUrl}${cccd}`).toPromise();
      
       this.items = await data;
       console.log(this.items);
    } catch (error) {
      this.error = 'Failed to load user roles';
      console.error('Error fetching user info:', error);
    } finally {
      this.loading = false; // Set loading indicator to false in all cases
    }
  }

  sendMessage(message: string) {
    this.webSocketService.sendMessage(message); // Send message to server
  }
  markAllAsRead() {
    this.messages.forEach(message => {
      message.isRead = true; // Đánh dấu tất cả thông báo là đã đọc
    });
    
    // Cập nhật số lượng tin nhắn chưa đọc
    this.updateUnreadCount();
  }
  
  updateUnreadCount() {
    const unreadMessages = this.messages.filter(message => !message.isRead);
    this.unreadCount = unreadMessages.length; // Cập nhật số lượng tin nhắn chưa đọc
  }
  deleteAllMessages() {
    const cccd = localStorage.getItem('cccd');
  
    this.http.delete(`${this.apiUrl}${cccd}`).subscribe({
      next: () => {
        this.getThongBaoByCccd();
        // Xóa tất cả tin nhắn từ giao diện sau khi API xóa thành công
        this.messages = [];
        this.updateUnreadCount(); // Cập nhật số lượng tin nhắn chưa đọc (nên là 0)
      },
      error: (err) => {
        console.error('Lỗi khi xóa thông báo:', err);
      }
    });
  }
  
  cancel() {
    this.modal.dismiss(null, 'cancel');
  }

  ngOnDestroy() {
    if (this.subscriptions) {
      this.subscriptions.unsubscribe();
    }
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
