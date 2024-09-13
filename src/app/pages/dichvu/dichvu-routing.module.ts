import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DichvuPage } from './dichvu.page';

const routes: Routes = [
  {
    path: '',
    component: DichvuPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DichvuPageRoutingModule {}
