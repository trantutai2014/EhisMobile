import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';



import { QrPageRoutingModule } from './QRCode-routing.module';

import { QrPage } from './QRCode.component';
import { QRCodeModule } from 'angularx-qrcode';
import { IonicModule } from '@ionic/angular';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    QrPageRoutingModule,
    QRCodeModule
  ],
  declarations: [QrPage]
})
export class QrPageModule { }
