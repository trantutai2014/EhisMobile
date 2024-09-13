import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';

@Component({
  selector: 'app-setting',
  templateUrl: './setting.page.html',
  styleUrls: ['./setting.page.scss'],
})
export class SettingPage implements OnInit {

  public actionSheetButtons = [
    {
      text: 'Delete',
      role: 'destructive',
      data: {
        action: 'delete',
      },
    },
    {
      text: 'Share',
      data: {
        action: 'share',
      },
    },
    {
      text: 'Cancel',
      role: 'cancel',
      data: {
        action: 'cancel',
      },
    },
  ];


  constructor(private router: Router) { }

  // async checkPermission() {
  //   const status = await BarcodeScanner.checkPermission({ force: true });
  //   if (status.granted) {
  //     return true;
  //   }
  // }

  startScan() {
  }

  ngOnInit() {
  }

  goToProFile() {
    this.router.navigate([UrlConstants.PROFILE]);
  }

  goToMain() {
    this.router.navigate([UrlConstants.MAIN]);
  }

  goToSetting() {
    this.router.navigate([UrlConstants.SETTING]);
  }

  goToHistory() {
    this.router.navigate([UrlConstants.HISTORY]);
  }

}
