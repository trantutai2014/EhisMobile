import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginQR } from './loginQR.component';

const routes: Routes = [
  {
    path: '',
    component:LoginQR,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginQRRoutingModule { }
