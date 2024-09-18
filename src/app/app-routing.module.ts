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
    loadChildren: () => import('./pages/thong-tin-hanh-chinh/thong-tin-hanh-chinh.module').then(m => m.ProfilePageModule)
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
    path: 'thong-tin-tiem-chung',
    loadChildren: () => import('./pages/thong-tin-tiem-chung/thong-tin-tiem-chung.module').then(m => m.ThongTinTiemChungPageModule)
  },
  {
    path: 'dich-vu',
    loadChildren: () => import('./pages/dichvu/dichvu.module').then(m => m.DichvuPageModule)
  },
  {
    path: 'benh-an',
    loadChildren: () => import('./pages/benhan/benhan.module').then(m => m.BenhanPageModule)
  },
  {
    path: 'ds-dot-kham-chua-benh',
    loadChildren: () => import('./pages/ds-dot-kham/ds-dot-kham.module').then(m => m.DotkhamPageModule)
  },
  {
    path: 'lich-su',
    loadChildren: () => import('./pages/lich-su/history.module').then(m => m.HistoryPageModule)
  },
  {
    path: 'setting',
    loadChildren: () => import('./pages/setting/setting.module').then(m => m.SettingPageModule)
  },
  {
    path: 'thong-tin-bhyt',
    loadChildren: () => import('./pages/thong-tin-bhyt/thong-tin-bhyt.module').then(m => m.ThongTinBHYTPageModule)
  },
  {
    path: 'user-role',
    loadChildren: () => import('./pages/user-role/user-role.module').then(m => m.UserRoleModule)
  },

];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
