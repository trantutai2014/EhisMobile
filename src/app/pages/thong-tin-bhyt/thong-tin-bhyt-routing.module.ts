import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ThongTinBHYTPage } from './thong-tin-bhyt.page';


const routes: Routes = [
  {
    path: '',
    component: ThongTinBHYTPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThongTinBHYTPageRoutingModule {}
