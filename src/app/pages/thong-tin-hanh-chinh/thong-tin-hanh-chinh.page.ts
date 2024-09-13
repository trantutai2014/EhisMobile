import { Component, OnInit } from '@angular/core';
import { profiles } from 'src/data/profile';
import { Router } from '@angular/router';
import { UrlConstants } from '../../core/constants/url.constant';

@Component({
  selector: 'app-profile',
  templateUrl: './thong-tin-hanh-chinh.page.html',
  styleUrls: ['./thong-tin-hanh-chinh.page.scss'],
})
export class ProfilePage implements OnInit {

  items: any[] = [];
  itemModel: any = {};


  constructor(private router: Router) { }

  ngOnInit() {
    this.items = [...profiles];
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
