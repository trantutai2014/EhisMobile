import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ChuanDoanXacDinhKhiRaVienPage } from './chuan-doan-xac-dinh-khi-ra-vien.page';

const routes: Routes = [
  {
    path: '',
    component: ChuanDoanXacDinhKhiRaVienPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ChuanDoanXacDinhKhiRaVienPageRoutingModule {}
