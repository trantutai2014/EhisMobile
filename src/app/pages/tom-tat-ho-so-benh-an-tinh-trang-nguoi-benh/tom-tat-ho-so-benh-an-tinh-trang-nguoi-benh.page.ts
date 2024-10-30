import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.prod';

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