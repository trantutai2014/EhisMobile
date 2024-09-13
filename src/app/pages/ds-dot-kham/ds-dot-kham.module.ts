import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DotkhamPageRoutingModule } from './ds-dotkham-routing.module';

import { DotkhamPage } from './ds-dot-kham.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DotkhamPageRoutingModule
  ],
  declarations: [DotkhamPage]
})
export class DotkhamPageModule { }
