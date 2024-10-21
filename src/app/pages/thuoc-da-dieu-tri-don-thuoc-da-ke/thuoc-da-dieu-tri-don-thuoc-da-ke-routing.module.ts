import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ThuocDaDieuTriDonThuocDaKePage } from './thuoc-da-dieu-tri-don-thuoc-da-ke.page';

const routes: Routes = [
  {
    path: '',
    component: ThuocDaDieuTriDonThuocDaKePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThuocDaDieuTriDonThuocDaKePageRoutingModule {}
