import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ThongBaoComponent } from './thong-bao.component';



const routes: Routes = [
  {
    path: 'thong-bao',
    component: ThongBaoComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MenuRoutingModule {}
