import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ThongTinDotKhamChuaBenhPage } from './thong-tin-dot-kham-chua-benh.page';

const routes: Routes = [
  {
    path: 'thong-tin-dot-kham-chua-benh/:id',
    component: ThongTinDotKhamChuaBenhPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThongTinDotKhamChuaBenhPageRoutingModule {}
