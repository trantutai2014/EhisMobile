import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ThongTinTiemChungPage } from './thong-tin-tiem-chung.page';



const routes: Routes = [
  {
    path: '',
    component: ThongTinTiemChungPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThongTinTiemChungPageRoutingModule {}
