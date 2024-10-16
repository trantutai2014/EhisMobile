import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent {


  constructor(private router: Router,
  ) { }

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
    const cccd = localStorage.getItem('cccd');
    if (cccd !== null) {
      this.router.navigate([UrlConstants.THONGTINHANHCHINH.replace(':cccd', cccd)]);
    
    }

  
 
  }
  goToThongTinTiemChung() {

    
 
    this.router.navigate([UrlConstants.THONGTINTIEMCHUNG]);
  }
  goToDSKhamChuaBenh() {
    const cccd = localStorage.getItem('cccd');
    if (cccd !== null) {
    this.router.navigate([UrlConstants.LICHSUBENH.replace(':cccd', cccd)]);
      
     
    }

    
  }
  goToThongTinBHYT() {
    const cccd = localStorage.getItem('cccd');
    if (cccd !== null) {
      this.router.navigate([UrlConstants.THONGTINBHYT.replace(':cccd', cccd)]);

    }


    
  }

  goToTrangChu() {
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
