import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.prod';
import { ChuanDoanHinhAnhThamDoChucNangPage } from '../chuan-doan-hinh-anh-tham-do-chuc-nang/chuan-doan-hinh-anh-tham-do-chuc-nang.page';

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
  component = ChuanDoanHinhAnhThamDoChucNangPage;

  constructor(private router: Router,  
              private route: ActivatedRoute,   
              private http: HttpClient) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const id = params['id'];
      const loaiHoSo = params['loaiHoSo'];
  
      if (id && loaiHoSo) {
        this.getPTTTData(id, loaiHoSo);
      } else {
        console.error('Missing required parameters: id and loaiHoSo');
      }
    });
  }
  
  getPTTTData(id: string, loaiHoSo: string): void {
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
