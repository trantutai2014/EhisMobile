import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { LichSuBenhPageRoutingModule } from './lich-su-benh-routing.module';

import { LichSuBenhPage } from './lich-su-benh.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    LichSuBenhPageRoutingModule
  ],
  declarations: [LichSuBenhPage]
})
export class LichSuBenhPageModule {}
