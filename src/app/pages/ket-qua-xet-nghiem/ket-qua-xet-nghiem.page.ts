import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.prod';
import { PhauThuatThuThuatDaThucHienPage } from '../phau-thuat-thu-thuat-da-thuc-hien/phau-thuat-thu-thuat-da-thuc-hien.page';

@Component({
  selector: 'app-thong-tin-xet-nghiem',
  templateUrl: './ket-qua-xet-nghiem.page.html',
  styleUrls: ['./ket-qua-xet-nghiem.page.scss'],
})
export class ThongTinXetNghiemPage implements OnInit {

  items: any[] = []; // Array to store the result from API
  loading: boolean = false;
  error: any;
  private apiUrl = `${environment.BASE_API}/api/ChiTietTienSuBenh/xet-nghiem/`;
  component = PhauThuatThuThuatDaThucHienPage;
  id: any;
  loai: any;
  ngayRa: Date = new Date();

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
