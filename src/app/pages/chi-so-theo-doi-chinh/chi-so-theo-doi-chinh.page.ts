import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.prod';
import { ChuanDoanXacDinhKhiRaVienPage } from '../chuan-doan-xac-dinh-khi-ra-vien/chuan-doan-xac-dinh-khi-ra-vien.page';
import { ChuanDoanHinhAnhThamDoChucNangPage } from '../chuan-doan-hinh-anh-tham-do-chuc-nang/chuan-doan-hinh-anh-tham-do-chuc-nang.page';
import { ThongTinXetNghiemPage } from '../ket-qua-xet-nghiem/ket-qua-xet-nghiem.page';
import { PhauThuatThuThuatDaThucHienPage } from '../phau-thuat-thu-thuat-da-thuc-hien/phau-thuat-thu-thuat-da-thuc-hien.page';
import { ThuocDaDieuTriDonThuocDaKePage } from '../thuoc-da-dieu-tri-don-thuoc-da-ke/thuoc-da-dieu-tri-don-thuoc-da-ke.page';
import { TomTatHoSoBenhAnTinhTrangNguoiBenhPage } from '../tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh/tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh.page';
import { ThongTinDotKhamChuaBenhPage } from '../thong-tin-dot-kham-chua-benh/thong-tin-dot-kham-chua-benh.page';

@Component({
  selector: 'app-chi-so-theo-doi-chinh',
  templateUrl: './chi-so-theo-doi-chinh.page.html',
  styleUrls: ['./chi-so-theo-doi-chinh.page.scss'],
})
export class ChiSoTheoDoiChinhPage implements OnInit {

  items: any;
  itemModel: any = {};
  loading: boolean = false;
  cccd: string | null | undefined;
  error: any;
  private apiUrl = `${environment.BASE_API}/api/DSDotKhamChuaBenh/`;
  component1 = ThongTinDotKhamChuaBenhPage;
  component2 = ChuanDoanXacDinhKhiRaVienPage;
  component3 = ThongTinXetNghiemPage;
  component4 = PhauThuatThuThuatDaThucHienPage;
  component5 = ChuanDoanHinhAnhThamDoChucNangPage;
  component6 = ThuocDaDieuTriDonThuocDaKePage;
  component7 = TomTatHoSoBenhAnTinhTrangNguoiBenhPage;

  constructor(private router: Router,  
    private route: ActivatedRoute,   
    private http: HttpClient) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.cccd = params.get('cccd');
      if (this.cccd) {
        this.getUserInfo();
      } else {
        // Handle case where CCCD is not found in URL
        console.error('Không tìm thấy CCCD trong URL');
      }
    });
  }

  


  getUserInfo(): void {
    this.loading = true; // Set loading indicator to true
    this.http.get(`${this.apiUrl}${this.cccd}`).subscribe({
      next: (data:any) => {
        this.loading = false; // Set loading indicator to false
          this.items=data.data;
      },
      error: (error) => {
        this.loading = false; // Set loading indicator to false
        this.error = 'Failed to load user roles';
      }
    });
  }
}
