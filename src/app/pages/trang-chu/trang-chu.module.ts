import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MainPageRoutingModule } from './trang-chu-routing.module';

import { MainPage } from './trang-chu.page';
import { RouterLink } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MainPageRoutingModule,
    RouterLink
  ],
  declarations: [MainPage],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class MainPageModule { }
