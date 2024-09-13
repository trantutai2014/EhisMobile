import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [

  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'thong-tin-hanh-chinh',
    loadChildren: () => import('./pages/profile/profile.module').then(m => m.ProfilePageModule)
  },
  {
    path: 'trang-chu',
    loadChildren: () => import('./pages/trang-chu/trang-chu.module').then(m => m.MainPageModule)
  },
  {
    path: 'admin',
    loadChildren: () => import('./pages/admin/admin.module').then(m => m.AdminPageModule)
  },
  {
    path: 'pay',
    loadChildren: () => import('./pages/pay/pay.module').then(m => m.PayPageModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./components/login/login.module').then(m => m.LoginFromModule)
  },
  {
    path: 'loginQR',
    loadChildren: () => import('./components/loginQR/loginQR.module').then(m => m.LoginQRModule)
  },
  {
    path: 'qr',
    loadChildren: () => import('./components/QRCode/QRCode.module').then(m => m.QrPageModule)
  },
  {
    path: 'thuoc',
    loadChildren: () => import('./pages/thuoc/thuoc.module').then(m => m.ThuocPageModule)
  },
  {
    path: 'dichvu',
    loadChildren: () => import('./pages/dichvu/dichvu.module').then(m => m.DichvuPageModule)
  },
  {
    path: 'benhan',
    loadChildren: () => import('./pages/benhan/benhan.module').then(m => m.BenhanPageModule)
  },
  {
    path: 'ds-dot-kham-chua-benh',
    loadChildren: () => import('./pages/ds-dot-kham/ds-dot-kham.module').then(m => m.DotkhamPageModule)
  },
  {
    path: 'setting',
    loadChildren: () => import('./pages/setting/setting.module').then(m => m.SettingPageModule)
  },

];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
