import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';
import { ThongTinTiemChungPageRoutingModule } from './thong-tin-tiem-chung-routing.module';
import { ThongTinTiemChungPage } from './thong-tin-tiem-chung.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ThongTinTiemChungPageRoutingModule
  ],
  declarations: [ThongTinTiemChungPage]
})
export class ThongTinTiemChungPageModule {}
