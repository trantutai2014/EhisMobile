import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: 'thong-tin-hanh-chinh/:cccd',
    loadChildren: () => import('./pages/thong-tin-hanh-chinh/thong-tin-hanh-chinh.module').then(m => m.ProfilePageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'trang-chu/:cccd',
    loadChildren: () => import('./pages/trang-chu/trang-chu.module').then(m => m.MainPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'admin',
    loadChildren: () => import('./pages/admin/admin.module').then(m => m.AdminPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'pay',
    loadChildren: () => import('./pages/pay/pay.module').then(m => m.PayPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'login',
    loadChildren: () => import('./components/login/login.module').then(m => m.LoginFromModule)
    // Không cần bảo vệ route này
  },
  {
    path: 'loginQR',
    loadChildren: () => import('./components/loginQR/loginQR.module').then(m => m.LoginQRModule)
    // Không cần bảo vệ route này
  },
  {
    path: 'qr',
    loadChildren: () => import('./components/QRCode/QRCode.module').then(m => m.QrPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'thong-tin-tiem-chung',
    loadChildren: () => import('./pages/thong-tin-tiem-chung/thong-tin-tiem-chung.module').then(m => m.ThongTinTiemChungPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'dich-vu',
    loadChildren: () => import('./pages/dichvu/dichvu.module').then(m => m.DichvuPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'benh-an',
    loadChildren: () => import('./pages/benhan/benhan.module').then(m => m.BenhanPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'ds-dot-kham-chua-benh/:cccd',
    loadChildren: () => import('./pages/ds-dot-kham/ds-dot-kham.module').then(m => m.DotkhamPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'lich-su',
    loadChildren: () => import('./pages/lich-su/history.module').then(m => m.HistoryPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'setting/:cccd',
    loadChildren: () => import('./pages/setting/setting.module').then(m => m.SettingPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'thong-tin-bhyt/:cccd',
    loadChildren: () => import('./pages/thong-tin-bhyt/thong-tin-bhyt.module').then(m => m.ThongTinBHYTPageModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'user-role',
    loadChildren: () => import('./pages/user-role/user-role.module').then(m => m.UserRoleModule),
    canActivate: [AuthGuard] // Bảo vệ route này
  },
  {
    path: 'lich-su-benh',
    loadChildren: () => import('./pages/lich-su-benh/lich-su-benh.module').then( m => m.LichSuBenhPageModule)
  },

];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
