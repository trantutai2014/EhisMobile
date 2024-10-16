import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-lich-su-benh',
  templateUrl: './lich-su-benh.page.html',
  styleUrls: ['./lich-su-benh.page.scss'],
})
export class LichSuBenhPage implements OnInit {
  items: any;
  itemModel: any = {};
  loading: boolean = false;
  cccd: string | null | undefined;
  error: any;
  private apiUrl = `${environment.BASE_API}/api/LichSuKhamBenh/`;

  constructor(private router: Router,  
    private route: ActivatedRoute,   
    private http: HttpClient) { }

    async ngOnInit() {
      this.route.paramMap.subscribe(async (params) => {
        this.cccd = params.get('cccd');
        if (this.cccd) {
          await this.getUserInfo();
        } else {
          console.error('Không tìm thấy CCCD trong URL');
        }
      });
    }
    


  
  goToDV() {
    this.router.navigate([UrlConstants.DICHVU]);
  }

  async getUserInfo(): Promise<void> {
    this.loading = true; // Set loading indicator to true
  
    try {
      const data: any = await this.http.get(`${this.apiUrl}${this.cccd}`).toPromise();
      // lấy data tiền Sử
       this.items = await data.tienSu;
    } catch (error) {
      this.error = 'Failed to load user roles';
      console.error('Error fetching user info:', error);
    } finally {
      this.loading = false; // Set loading indicator to false in all cases
    }
  }
  

  goToDSKhamChuaBenh(index: number) {
    const cccd = localStorage.getItem('cccd');
    if (cccd !== null && this.items[index]) {
      const queryParams = {
        
        id: this.items[index].id,
        loaiHoSo: this.items[index].loaiHoSo,
        ngayRa: this.items[index].ngayRa
      };
  
      this.router.navigate(
        [UrlConstants.DSDOTKHAMCHUABENH.replace(':cccd', cccd)], 
        { queryParams }
      );
    }
  }
  
}



