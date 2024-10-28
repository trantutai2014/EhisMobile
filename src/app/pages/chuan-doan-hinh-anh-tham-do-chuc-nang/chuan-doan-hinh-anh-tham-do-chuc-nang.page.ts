import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.prod';
import { ThuocDaDieuTriDonThuocDaKePage } from '../thuoc-da-dieu-tri-don-thuoc-da-ke/thuoc-da-dieu-tri-don-thuoc-da-ke.page';

@Component({
  selector: 'app-chuan-doan-hinh-anh-tham-do-chuc-nang',
  templateUrl: './chuan-doan-hinh-anh-tham-do-chuc-nang.page.html',
  styleUrls: ['./chuan-doan-hinh-anh-tham-do-chuc-nang.page.scss'],
})
export class ChuanDoanHinhAnhThamDoChucNangPage implements OnInit {

  items: any;
  loading: boolean = false;
  error: any;
  private apiUrl = `${environment.BASE_API}/api/ChiTietTienSuBenh/cdha-tdcn/`;
  component = ThuocDaDieuTriDonThuocDaKePage;

  constructor(private router: Router,
              private route: ActivatedRoute,
              private http: HttpClient) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const id = params['id'];
      const loaiHoSo = params['loaiHoSo'];

      if (id && loaiHoSo) {
        this.getCDHAData(id, loaiHoSo);
      } else {
        console.error('Missing required parameters: id and loaiHoSo');
      }
    });
  }

  getCDHAData(id: string, loaiHoSo: string): void {
    this.loading = true;

    this.http.get(`${this.apiUrl}?id=${id}&loai=${loaiHoSo}`).subscribe({
      next: (data: any) => {
        this.loading = false;
        this.items = data;

        // Handle potential missing data
        if (!data || !Array.isArray(data) || !data.length) {
          this.items = []; // Set an empty array to display "Không có thông tin"
        }
      },
      error: (error) => {
        this.loading = false;
        this.error = 'Failed to load data';
        console.error('Error fetching data:', error);
      }
    });
  }
}