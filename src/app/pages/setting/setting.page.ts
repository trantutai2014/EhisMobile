import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SystemConstants } from 'src/app/core/constants/system.constants';
import { UrlConstants } from 'src/app/core/constants/url.constant';
import { AuthService } from 'src/app/core/services/auth.service';
@Component({
  selector: 'app-setting',
  templateUrl: './setting.page.html',
  styleUrls: ['./setting.page.scss'],
})
export class SettingPage implements OnInit {
  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
  }
  goToDV() {
    this.router.navigate([UrlConstants.DICHVU]);
  }
  logout() {
    this.authService.logout();
   
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
}
