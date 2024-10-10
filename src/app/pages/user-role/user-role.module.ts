import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoleComponent } from './user-role.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { UserRoleRoutingModule } from './user-role-routing.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    UserRoleRoutingModule
  ]
})
export class UserRoleModule { }
