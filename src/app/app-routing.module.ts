import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [

  {
    path: '',
    redirectTo: 'trang-chu',
    pathMatch: 'full'
  },
  {
    path: 'thong-tin-hanh-chinh',
    loadChildren: () => import('./pages/thong-tin-hanh-chinh/thong-tin-hanh-chinh.module').then(m => m.ProfilePageModule)
  },
  {
    path: 'trang-chu',
    loadChildren: () => import('./pages/trang-chu/trang-chu.module').then(m => m.MainPageModule),

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
 
  {
    path: 'thong-tin-dot-kham-chua-benh',
    loadChildren: () => import('./pages/thong-tin-dot-kham-chua-benh/thong-tin-dot-kham-chua-benh.module').then( m => m.ThongTinDotKhamChuaBenhPageModule)
  },  {
    path: 'chuan-doan-xac-dinh-khi-ra-vien',
    loadChildren: () => import('./pages/chuan-doan-xac-dinh-khi-ra-vien/chuan-doan-xac-dinh-khi-ra-vien.module').then( m => m.ChuanDoanXacDinhKhiRaVienPageModule)
  },
  {
    path: 'chi-so-theo-doi-chinh',
    loadChildren: () => import('./pages/chi-so-theo-doi-chinh/chi-so-theo-doi-chinh.module').then( m => m.ChiSoTheoDoiChinhPageModule)
  },
  {
    path: 'tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh',
    loadChildren: () => import('./pages/tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh/tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh.module').then( m => m.TomTatHoSoBenhAnTinhTrangNguoiBenhPageModule)
  },
  {
    path: 'chuan-doan-hinh-anh-tham-do-chuc-nang',
    loadChildren: () => import('./pages/chuan-doan-hinh-anh-tham-do-chuc-nang/chuan-doan-hinh-anh-tham-do-chuc-nang.module').then( m => m.ChuanDoanHinhAnhThamDoChucNangPageModule)
  },
  {
    path: 'thong-tin-xet-nghiem',
    loadChildren: () => import('./pages/thong-tin-xet-nghiem/thong-tin-xet-nghiem.module').then( m => m.ThongTinXetNghiemPageModule)
  },
  {
    path: 'phau-thuat-thu-thuat-da-thuc-hien',
    loadChildren: () => import('./pages/phau-thuat-thu-thuat-da-thuc-hien/phau-thuat-thu-thuat-da-thuc-hien.module').then( m => m.PhauThuatThuThuatDaThucHienPageModule)
  },



];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
