import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ThuocPage } from './thuoc.page';

const routes: Routes = [
  {
    path: '',
    component: ThuocPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThuocPageRoutingModule {}
