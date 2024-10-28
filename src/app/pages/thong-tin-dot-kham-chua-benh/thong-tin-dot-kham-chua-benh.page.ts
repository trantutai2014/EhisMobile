import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-thong-tin-dot-kham-chua-benh',
  templateUrl: './thong-tin-dot-kham-chua-benh.page.html',
  styleUrls: ['./thong-tin-dot-kham-chua-benh.page.scss'],
})
export class ThongTinDotKhamChuaBenhPage implements OnInit {
  items: any;
  loading: boolean = false;
  id: string | null | undefined;  // Update this to be the ID from lich-su-kham or ds-dot-kham
  error: any;
  private apiUrl = `${environment.BASE_API}/api/ChiTietTienSuBenh/lich-su-kcb`; // Updated endpoint
  ngayRa: Date = new Date(); // You can update this as per the actual date to send
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
      },
      error: (error) => {
        this.loading = false;
        this.error = 'Failed to load user data';
        console.error('Error:', error);
      }
    });
  }
  
}
