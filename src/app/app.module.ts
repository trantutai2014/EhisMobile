import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { MenuComponent } from './layouts/menu/menu.component';
import { ProfilePage } from './pages/thong-tin-hanh-chinh/thong-tin-hanh-chinh.page';
import { ThongBaoComponent } from './layouts/thong-bao/thong-bao.component';
import { CapNhatComponent } from './components/cap-nhat/cap-nhat.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginService } from './core/services/login.service';
import { ValidatorService } from './core/services/validator.service';
import { UserRoleModule } from './pages/user-role/user-role.module';
import { UserRoleComponent } from './pages/user-role/user-role.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './core/guards/jwt.interceptor';
import { ApiInterceptor } from './core/interceptor/thong-bao.interceptor';
@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [
    AppComponent,
    MenuComponent,
    ThongBaoComponent,
    CapNhatComponent,
    UserRoleComponent,
  
   
  ],
  imports: [
    BrowserModule, 
    IonicModule.forRoot(), 
    AppRoutingModule,
    HttpClientModule,
    UserRoleModule,
    

  ],
  providers: [
    LoginService,
    ValidatorService,
    {
      provide: RouteReuseStrategy,
      useClass: IonicRouteStrategy
    },
    { provide: HTTP_INTERCEPTORS,
       useClass: JwtInterceptor, 
       multi: true 
    },
    {
       provide: HTTP_INTERCEPTORS, useClass: ApiInterceptor, multi: true 
    }
    
      ],
  bootstrap: [AppComponent],
})
export class AppModule { }
