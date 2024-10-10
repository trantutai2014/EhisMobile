import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DichvuPageRoutingModule } from './dichvu-routing.module';

import { DichvuPage } from './dichvu.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DichvuPageRoutingModule
  ],
  declarations: [DichvuPage]
})
export class DichvuPageModule {}
