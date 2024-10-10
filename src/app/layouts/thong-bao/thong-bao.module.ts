import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';
import { ThongBaoComponent } from './thong-bao.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
  ],
  declarations: []
})
export class ThongBaoModule {
  constructor(private router: Router) {}

  ngOnInit() {
  }

 }
