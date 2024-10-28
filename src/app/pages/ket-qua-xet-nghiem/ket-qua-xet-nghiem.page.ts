import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-thong-tin-xet-nghiem',
  templateUrl: './ket-qua-xet-nghiem.page.html',
  styleUrls: ['./ket-qua-xet-nghiem.page.scss'],
})
export class ThongTinXetNghiemPage implements OnInit {

  items: any[] = []; // Array to store the result from API
  loading: boolean = false;
  cccd: string | null | undefined;
  error: any;
  private apiUrl = `${environment.BASE_API}/api/ChiTietTienSuBenh/xet-nghiem/`;

  constructor(
    private router: Router,  
    private route: ActivatedRoute,   
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const id = params['id'];
      const loaiHoSo = params['loaiHoSo'];
  
      if (id && loaiHoSo) {
        this.getXetNghiemData(id, loaiHoSo);
      } else {
        console.error('Missing required parameters: id and loaiHoSo');
      }
    });
  }
  
  getXetNghiemData(id: string, loaiHoSo: string): void {
    this.loading = true;
    this.http.get<any[]>(`${this.apiUrl}?id=${id}&loai=${loaiHoSo}`).subscribe({
      next: (data) => {
        this.loading = false;
        this.items = data; // Save the data from API response
      },
      error: (error) => {
        this.loading = false;
        this.error = 'Failed to load data';
        console.error('Error fetching data:', error);
      }
    });
  }
}
