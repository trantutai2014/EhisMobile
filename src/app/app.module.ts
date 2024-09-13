import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { LoginService } from './core/services/login.service';
import { MenuComponent } from './layouts/menu/menu.component';
import { ProfilePage } from './pages/thong-tin-hanh-chinh/thong-tin-hanh-chinh.page';
import { ThongBaoComponent } from './layouts/thong-bao/thong-bao.component';
import { CapNhatComponent } from './components/cap-nhat/cap-nhat.component';

@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [
    AppComponent,
    MenuComponent,
    ThongBaoComponent,
    CapNhatComponent,
  ],
  imports: [
    BrowserModule, 
    IonicModule.forRoot(), 
    AppRoutingModule,

  ],
  providers: [
    LoginService,
    {
      provide: RouteReuseStrategy,
      useClass: IonicRouteStrategy
    }],
  bootstrap: [AppComponent],
})
export class AppModule { }
