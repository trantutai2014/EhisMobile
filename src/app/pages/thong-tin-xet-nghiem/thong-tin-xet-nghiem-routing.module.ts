import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ThongTinXetNghiemPage } from './thong-tin-xet-nghiem.page';

const routes: Routes = [
  {
    path: '',
    component: ThongTinXetNghiemPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThongTinXetNghiemPageRoutingModule {}