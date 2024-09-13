import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { QrPage } from './QRCode.component';

const routes: Routes = [
  {
    path: '',
    component: QrPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class QrPageRoutingModule {}
