import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ChiSoTheoDoiChinhPage } from './chi-so-theo-doi-chinh.page';

const routes: Routes = [
  {
    path: '',
    component: ChiSoTheoDoiChinhPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ChiSoTheoDoiChinhPageRoutingModule {}
