import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DotkhamPageRoutingModule } from './ds-dotkham-routing.module';
import {ThongTinDotKhamChuaBenhPage} from '../thong-tin-dot-kham-chua-benh/thong-tin-dot-kham-chua-benh.page';
import {ChuanDoanXacDinhKhiRaVienPage} from '../chuan-doan-xac-dinh-khi-ra-vien/chuan-doan-xac-dinh-khi-ra-vien.page';
import { DotkhamPage } from './ds-dot-kham.page';
import{ChiSoTheoDoiChinhPage} from '../chi-so-theo-doi-chinh/chi-so-theo-doi-chinh.page';
import{TomTatHoSoBenhAnTinhTrangNguoiBenhPage} from '../tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh/tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh.page';
import{ThongTinXetNghiemPage} from '../thong-tin-xet-nghiem/thong-tin-xet-nghiem.page';
import{PhauThuatThuThuatDaThucHienPage} from '../phau-thuat-thu-thuat-da-thuc-hien/phau-thuat-thu-thuat-da-thuc-hien.page';
import { ChuanDoanHinhAnhThamDoChucNangPage } from '../chuan-doan-hinh-anh-tham-do-chuc-nang/chuan-doan-hinh-anh-tham-do-chuc-nang.page';
import { ThuocDaDieuTriDonThuocDaKePage } from '../thuoc-da-dieu-tri-don-thuoc-da-ke/thuoc-da-dieu-tri-don-thuoc-da-ke.page';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DotkhamPageRoutingModule,
    
  ],
  declarations: [DotkhamPage,
    ThongTinDotKhamChuaBenhPage, 
    ChuanDoanXacDinhKhiRaVienPage, 
    ChiSoTheoDoiChinhPage,
    TomTatHoSoBenhAnTinhTrangNguoiBenhPage,
    ThongTinXetNghiemPage,
    PhauThuatThuThuatDaThucHienPage,
    ChuanDoanHinhAnhThamDoChucNangPage,
    ThuocDaDieuTriDonThuocDaKePage],

})
export class DotkhamPageModule { }
