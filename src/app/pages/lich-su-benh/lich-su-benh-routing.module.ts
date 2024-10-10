import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LichSuBenhPage } from './lich-su-benh.page';

const routes: Routes = [
  {
    path: '',
    component: LichSuBenhPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LichSuBenhPageRoutingModule {}
