import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DotkhamPage } from './ds-dot-kham.page';

const routes: Routes = [
  {
    path: '',
    component: DotkhamPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DotkhamPageRoutingModule {}
