import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';
import { ThongTinBHYTPageRoutingModule } from './thong-tin-bhyt-routing.module';
import { ThongTinBHYTPage } from './thong-tin-bhyt.page';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ThongTinBHYTPageRoutingModule
  ],
  declarations: [ThongTinBHYTPage]
})
export class ThongTinBHYTPageModule { }
