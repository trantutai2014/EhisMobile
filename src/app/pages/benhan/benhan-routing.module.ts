import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BenhanPage } from './benhan.page';

const routes: Routes = [
  {
    path: '',
    component: BenhanPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BenhanPageRoutingModule {}
