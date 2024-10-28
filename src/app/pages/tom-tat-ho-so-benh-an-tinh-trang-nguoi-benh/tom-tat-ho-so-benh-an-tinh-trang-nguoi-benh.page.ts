import { HttpClient } from '@angular/common/http';
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
  itemModel: any = {};
  loading: boolean = false;
  cccd: string | null | undefined;
  error: any;
  private apiUrl = `${environment.BASE_API}/api/ChiTietTienSuBenh/tom-tat/`;

  constructor(private router: Router,  
    private route: ActivatedRoute,   
    private http: HttpClient) { }

    ngOnInit(): void {
      this.route.queryParams.subscribe(params => {
        const id = params['id']; // Retrieve 'id' from query params
        const loaiHoSo = params['loaiHoSo']; // Retrieve 'loaiHoSo' from query params
  
        if (id && loaiHoSo) {
          this.getTomTatData(id, loaiHoSo);
        } else {
          console.error('Missing required parameters: id and loaiHoSo');
        }
      });
    }
  
    getTomTatData(id: string, loaiHoSo: string): void {
      this.loading = true;
    
      this.http.get(`${this.apiUrl}?id=${id}&loai=${loaiHoSo}`).subscribe({
        next: (data: any) => {
          this.loading = false;
          this.items = data || null; // Gán null nếu data không có giá trị
        },
        error: (error) => {
          this.loading = false;
          this.error = 'Failed to load data';
          console.error('Error fetching data:', error);
        }
      });
    }
    
    }
