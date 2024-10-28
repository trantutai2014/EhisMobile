import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SystemConstants } from 'src/app/core/constants/system.constants';
import { UrlConstants } from 'src/app/core/constants/url.constant';
import { AuthService } from 'src/app/core/services/auth.service';
import { environment } from 'src/environments/environment.prod';
@Component({
  selector: 'app-setting',
  templateUrl: './setting.page.html',
  styleUrls: ['./setting.page.scss'],
})
export class SettingPage implements OnInit {
  constructor(private router: Router, private authService: AuthService,
    private route: ActivatedRoute,   
    private http: HttpClient
  ) { }

  items: any;
  itemModel: any = {};
  loading: boolean = false;
  cccd: string | null | undefined;
  error: any;

  private apiUrl = `${environment.BASE_API}/api/DSDotKhamChuaBenh/`;

 

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
          this.items=data.data;
      },
      error: (error) => {
        this.loading = false; // Set loading indicator to false
        this.error = 'Failed to load user roles';
      }
    });
  }

  goToDV() {
    this.router.navigate([UrlConstants.DICHVU]);
  }
  logout() {
    this.authService.logout();
   
  }
  goToProFile() {
    const cccd = localStorage.getItem('cccd');
    if (cccd !== null) {
      this.router.navigate([UrlConstants.THONGTINHANHCHINH.replace(':cccd', cccd)]);

    }
  }

  goToMain() {
    const cccd = localStorage.getItem('cccd');
    if (cccd !== null) {
      this.router.navigate([UrlConstants.TRANGCHU.replace(':cccd',cccd)]);


    }
  }

  goToSetting() {
    const cccd = localStorage.getItem('cccd');
    if (cccd !== null) {
      this.router.navigate([UrlConstants.SETTING.replace(':cccd', cccd)]);

    }
  }

  goToHistory() {
    this.router.navigate([UrlConstants.LICHSU]);
  }
}
