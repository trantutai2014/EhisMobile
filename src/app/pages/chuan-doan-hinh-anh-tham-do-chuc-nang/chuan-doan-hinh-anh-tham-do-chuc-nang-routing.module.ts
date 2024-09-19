import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ChuanDoanHinhAnhThamDoChucNangPage } from './chuan-doan-hinh-anh-tham-do-chuc-nang.page';

const routes: Routes = [
  {
    path: '',
    component: ChuanDoanHinhAnhThamDoChucNangPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ChuanDoanHinhAnhThamDoChucNangPageRoutingModule {}
