import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PhauThuatThuThuatDaThucHienPage } from './phau-thuat-thu-thuat-da-thuc-hien.page';

const routes: Routes = [
  {
    path: '',
    component: PhauThuatThuThuatDaThucHienPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PhauThuatThuThuatDaThucHienPageRoutingModule {}
