import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SystemConstants } from 'src/app/core/constants/system.constants';
import { UrlConstants } from 'src/app/core/constants/url.constant';

@Component({
  selector: 'app-setting',
  templateUrl: './setting.page.html',
  styleUrls: ['./setting.page.scss'],
})
export class SettingPage implements OnInit {
  constructor(private router: Router) { }

  ngOnInit() {
  }
  goToDV() {
    this.router.navigate([UrlConstants.DICHVU]);
  }
  logout() {
    localStorage.removeItem(SystemConstants.CURRENT_USER);
    this.router.navigate([UrlConstants.LOGIN]);
  }
}
