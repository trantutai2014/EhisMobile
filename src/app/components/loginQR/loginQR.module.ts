import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { LoginQR } from './loginQR.component';

import { LoginQRRoutingModule } from './loginQR-routing.module';
import { QRCodeModule } from 'angularx-qrcode';
import { RouterLink } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    LoginQRRoutingModule,
    QRCodeModule,
    RouterLink
  ],
  declarations: [LoginQR]
})
export class LoginQRModule { }
