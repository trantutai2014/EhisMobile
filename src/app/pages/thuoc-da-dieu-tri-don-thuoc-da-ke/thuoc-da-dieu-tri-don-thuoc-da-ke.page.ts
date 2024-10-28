import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-thuoc-da-dieu-tri-don-thuoc-da-ke',
  templateUrl: './thuoc-da-dieu-tri-don-thuoc-da-ke.page.html',
  styleUrls: ['./thuoc-da-dieu-tri-don-thuoc-da-ke.page.scss'],
})
export class ThuocDaDieuTriDonThuocDaKePage implements OnInit {
  loading: boolean | undefined;
  items: any[] = []; // Updated to an array to handle the list of drugs
  error: string | undefined;
  private apiUrl = `${environment.BASE_API}/api/ChiTietTienSuBenh/thuoc/`;

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const id = params['id']; // Retrieve 'id' from query params
      const loaiHoSo = params['loaiHoSo']; // Retrieve 'loaiHoSo' from query params

      if (id && loaiHoSo) {
        this.getThuocData(id, loaiHoSo);
      } else {
        console.error('Missing required parameters: id and loaiHoSo');
      }
    });
  }

  getThuocData(id: string, loaiHoSo: string): void {
    this.loading = true;

    this.http.get(`${this.apiUrl}?id=${id}&loai=${loaiHoSo}`).subscribe({
      next: (data: any) => {
        this.loading = false;
        this.items = data; // Assuming the API directly returns the array of drugs
      },
      error: (error) => {
        this.loading = false;
        this.error = 'Failed to load drug data';
        console.error('Error fetching drug data:', error);
      }
    });
  }
}
