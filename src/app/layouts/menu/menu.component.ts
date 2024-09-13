import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent {
  constructor(private router: Router) {}

  navigateTo(page: string) {
    this.router.navigateByUrl(`/${page}`);
  }

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

  goToThongTinHanhChinh() {
    this.router.navigate([UrlConstants.THONGTINHANHCHINH]);
  }
  goToThongTinTiemChung() {
    this.router.navigate([UrlConstants.THONGTINTIEMCHUNG]);
  }
  goToDSKhamChuaBenh() {
    this.router.navigate([UrlConstants.DSDOTKHAMCHUABENH]);
  }
  goToThongTinBHYT() {
    this.router.navigate([UrlConstants.THONGTINBHYT]);
  }

  goToTrangChu() {
    this.router.navigate([UrlConstants.TRANGCHU]);
  }

  goToSetting() {
    this.router.navigate([UrlConstants.SETTING]);
  }

  goToHistory() {
    this.router.navigate([UrlConstants.LICHSU]);
  }

}
