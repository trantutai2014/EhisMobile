import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CapNhatComponent } from './cap-nhat.component';



const routes: Routes = [
  {
    path: 'cap-nhat',
    component: CapNhatComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CapNhatRoutingModule {}
