import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TomTatHoSoBenhAnTinhTrangNguoiBenhPage } from './tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh.page';

const routes: Routes = [
  {
    path: '',
    component: TomTatHoSoBenhAnTinhTrangNguoiBenhPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TomTatHoSoBenhAnTinhTrangNguoiBenhPageRoutingModule {}
