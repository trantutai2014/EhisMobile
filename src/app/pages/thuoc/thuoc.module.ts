import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ThuocPageRoutingModule } from './thuoc-routing.module';

import { ThuocPage } from './thuoc.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ThuocPageRoutingModule
  ],
  declarations: [ThuocPage]
})
export class ThuocPageModule {}
