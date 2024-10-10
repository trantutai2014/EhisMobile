import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MenuComponent } from './menu.component';
import { IonicModule } from '@ionic/angular';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
  ],
  declarations: []
})
export class MenuModule {
  constructor(private router: Router) {}

  ngOnInit() {
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
