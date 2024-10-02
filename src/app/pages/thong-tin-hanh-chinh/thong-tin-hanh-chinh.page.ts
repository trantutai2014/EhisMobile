import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UrlConstants } from '../../core/constants/url.constant';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-profile',
  templateUrl: './thong-tin-hanh-chinh.page.html',
  styleUrls: ['./thong-tin-hanh-chinh.page.scss'],
})
export class ProfilePage implements OnInit {
  items: any;
  itemModel: any = {};
  loading: boolean = false;
  cccd: string | null | undefined;
  error: any;

  private apiUrl = `${environment.BASE_API}/api/QRCode/`;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private router: Router,
    private cdr:ChangeDetectorRef
  ) {}

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
  }

  getUserInfo(): void {
    this.loading = true; // Set loading indicator to true
    this.http.get(`${this.apiUrl}${this.cccd}`).subscribe({
      next: (data:any) => {
        this.loading = false; // Set loading indicator to false
          this.items=data.qrCodeData;
         console.log(data);
      },
      error: (error) => {
        this.loading = false; // Set loading indicator to false
        this.error = 'Failed to load user roles';
      }
    });
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

  goToHistory() {
    this.router.navigate([UrlConstants.LICHSU]);
  }

  goToDV() {
    this.router.navigate([UrlConstants.DICHVU]);
  }
}