import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ChiSoTheoDoiChinhPageRoutingModule } from './chi-so-theo-doi-chinh-routing.module';

import { ChiSoTheoDoiChinhPage } from './chi-so-theo-doi-chinh.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ChiSoTheoDoiChinhPageRoutingModule
  ],
  declarations: []
})
export class ChiSoTheoDoiChinhPageModule {}
