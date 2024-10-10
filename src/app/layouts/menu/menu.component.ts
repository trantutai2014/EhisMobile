import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';
import { CccdService } from 'src/app/core/services/cccd.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent {


  constructor(private router: Router,
    private cccdService: CccdService,
    
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
   const cccd = this.cccdService.getCccd(); 

  }

  goToThongTinHanhChinh() {
    const cccd = localStorage.getItem('cccd');
    if (cccd !== null) {
      this.router.navigate([UrlConstants.THONGTINHANHCHINH.replace(':cccd', cccd)]);
    
    }

  
 
  }
  goToThongTinTiemChung() {

    
    const cccd = this.cccdService.getCccd(); 
    this.router.navigate([UrlConstants.THONGTINTIEMCHUNG]);
  }
  goToDSKhamChuaBenh() {
    const cccd = localStorage.getItem('cccd');
    if (cccd !== null) {
    this.router.navigate([UrlConstants.DSDOTKHAMCHUABENH.replace(':cccd', cccd)]);
      
     
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
