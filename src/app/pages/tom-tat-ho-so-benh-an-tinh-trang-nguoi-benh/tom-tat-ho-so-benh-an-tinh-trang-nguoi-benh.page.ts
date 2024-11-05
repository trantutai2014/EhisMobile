import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.prod';
import { ChiSoTheoDoiChinhPage } from '../chi-so-theo-doi-chinh/chi-so-theo-doi-chinh.page';
import { ChuanDoanHinhAnhThamDoChucNangPage } from '../chuan-doan-hinh-anh-tham-do-chuc-nang/chuan-doan-hinh-anh-tham-do-chuc-nang.page';
import { ChuanDoanXacDinhKhiRaVienPage } from '../chuan-doan-xac-dinh-khi-ra-vien/chuan-doan-xac-dinh-khi-ra-vien.page';
import { ThongTinXetNghiemPage } from '../ket-qua-xet-nghiem/ket-qua-xet-nghiem.page';
import { PhauThuatThuThuatDaThucHienPage } from '../phau-thuat-thu-thuat-da-thuc-hien/phau-thuat-thu-thuat-da-thuc-hien.page';
import { ThongTinDotKhamChuaBenhPage } from '../thong-tin-dot-kham-chua-benh/thong-tin-dot-kham-chua-benh.page';
import { ThuocDaDieuTriDonThuocDaKePage } from '../thuoc-da-dieu-tri-don-thuoc-da-ke/thuoc-da-dieu-tri-don-thuoc-da-ke.page';

@Component({
  selector: 'app-tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh',
  templateUrl: './tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh.page.html',
  styleUrls: ['./tom-tat-ho-so-benh-an-tinh-trang-nguoi-benh.page.scss'],
})
export class TomTatHoSoBenhAnTinhTrangNguoiBenhPage implements OnInit {

  items: any;
  loading: boolean = false;
  error: string | null = null;
  private apiUrl = `${environment.BASE_API}/api/ChiTietTienSuBenh/tom-tat/`;
  ngayRa: Date = new Date();
  id: any;
  loai: any;
  component1 = ThongTinDotKhamChuaBenhPage;
  component2 = ChuanDoanXacDinhKhiRaVienPage;
  component3 = ChiSoTheoDoiChinhPage;
  component4 = ThongTinXetNghiemPage;
  component5 = ChuanDoanHinhAnhThamDoChucNangPage;
  component6 = PhauThuatThuThuatDaThucHienPage;
  component7 = ThuocDaDieuTriDonThuocDaKePage

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
  
      this.http.get<any>(this.apiUrl, { params }).subscribe({
        next: (data) => {
          this.loading = false;
          // Kiểm tra xem data có phải là mảng hay không
          this.items = Array.isArray(data) ? data : [data]; // Nếu không phải, chuyển thành mảng
        },
        error: (error) => {
          this.loading = false;
          this.error = 'Không thể tải dữ liệu';
          console.error('Error:', error);
        }
      });
    }
}