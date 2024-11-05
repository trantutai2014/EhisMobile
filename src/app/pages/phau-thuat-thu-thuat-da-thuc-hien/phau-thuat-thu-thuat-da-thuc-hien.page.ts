import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.prod';
import { ChuanDoanHinhAnhThamDoChucNangPage } from '../chuan-doan-hinh-anh-tham-do-chuc-nang/chuan-doan-hinh-anh-tham-do-chuc-nang.page';
import { ChiSoTheoDoiChinhPage } from '../chi-so-theo-doi-chinh/chi-so-theo-doi-chinh.page';
import { ChuanDoanXacDinhKhiRaVienPage } from '../chuan-doan-xac-dinh-khi-ra-vien/chuan-doan-xac-dinh-khi-ra-vien.page';
import { ThongTinDotKhamChuaBenhPage } from '../thong-tin-dot-kham-chua-benh/thong-tin-dot-kham-chua-benh.page';
import { ThuocDaDieuTriDonThuocDaKePage } from '../thuoc-da-dieu-tri-don-thuoc-da-ke/thuoc-da-dieu-tri-don-thuoc-da-ke.page';
import { TomTatHoSoBenhAnTinhTrangNguoiBenhPage } from '../tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh/tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh.page';
import { ThongTinXetNghiemPage } from '../ket-qua-xet-nghiem/ket-qua-xet-nghiem.page';

@Component({
  selector: 'app-phau-thuat-thu-thuat-da-thuc-hien',
  templateUrl: './phau-thuat-thu-thuat-da-thuc-hien.page.html',
  styleUrls: ['./phau-thuat-thu-thuat-da-thuc-hien.page.scss'],
})
export class PhauThuatThuThuatDaThucHienPage implements OnInit {

  items: any;
  itemModel: any = {};
  loading: boolean = false;
  error: any;
  private apiUrl = `${environment.BASE_API}/api/ChiTietTienSuBenh/pttt/`;
  component1 = ThongTinDotKhamChuaBenhPage;
  component2 = ChuanDoanXacDinhKhiRaVienPage;
  component3 = ChiSoTheoDoiChinhPage;
  component4 = ThongTinXetNghiemPage;
  component5 = ChuanDoanHinhAnhThamDoChucNangPage;
  component6 = ThuocDaDieuTriDonThuocDaKePage;
  component7 = TomTatHoSoBenhAnTinhTrangNguoiBenhPage;

  ngayRa: Date = new Date();
  id: any;
  loai: any;

  constructor(
    private router: Router,  
    private route: ActivatedRoute,   
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.id = params['id']; // Get 'id' from the queryParams
      this.loai = params['loaiHoSo']; // Get 'loaiHoSo' from the queryParams
      if (this.id && this.loai) {
        this.getUserInfo(); // Call the API with correct id and loaiHoSo
      } else {
        console.error('ID or loaiHoSo not found in URL');
      }
    });
  }
  
  getUserInfo(): void {
    this.loading = true;
  
    if (!this.id || !this.loai) {
      this.loading = false;
      console.error('ID or loaiHoSo is missing');
      return;
    }
  
    const queryParams = {
      id: this.id,          // Use the id
      loai: this.loai,      // Use the loaiHoSo from lich-su-kham
      p: this.ngayRa.toISOString()  // Date formatted as string
    };
  
    const params = new HttpParams()
      .set('id', queryParams.id)
      .set('loai', queryParams.loai)
      .set('p', queryParams.p);
  
    this.http.get(this.apiUrl, { params }).subscribe({
      next: (data: any) => {
        this.loading = false;
        this.items = data; // Handle API response
        console.log(data);
      },
      error: (error) => {
        this.loading = false;
        this.error = 'Failed to load user data';
        console.error('Error:', error);
      }
    });
  }
  
}
