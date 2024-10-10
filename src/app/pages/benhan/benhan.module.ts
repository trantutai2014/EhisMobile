import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { BenhanPageRoutingModule } from './benhan-routing.module';

import { BenhanPage } from './benhan.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    BenhanPageRoutingModule
  ],
  declarations: [BenhanPage]
})
export class BenhanPageModule {}
