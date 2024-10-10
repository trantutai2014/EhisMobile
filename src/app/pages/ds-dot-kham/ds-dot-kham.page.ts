import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-dotkham',
  templateUrl: './ds-dot-kham.page.html',
  styleUrls: ['./ds-dot-kham.page.scss'],
})
export class DotkhamPage implements OnInit {
  items: any;
  itemModel: any = {};
  loading: boolean = false;
  cccd: string | null | undefined;
  error: any;

  private apiUrl = `${environment.BASE_API}/api/DSDotKhamChuaBenh/`;

  constructor(private router: Router,  
    private route: ActivatedRoute,   
    private http: HttpClient) { }

  ngOnInit() {

    this.route.paramMap.subscribe(params => {
      this.cccd = params.get('cccd');
      if (this.cccd) {
        this.getUserInfo();
      } else {
        // Handle case where CCCD is not found in URL
        console.error('Không tìm thấy CCCD trong URL');
      }
    });
  }

  getUserInfo(): void {
    this.loading = true; // Set loading indicator to true
    this.http.get(`${this.apiUrl}${this.cccd}`).subscribe({
      next: (data:any) => {
        this.loading = false; // Set loading indicator to false
          this.items=data.data;
      },
      error: (error) => {
        this.loading = false; // Set loading indicator to false
        this.error = 'Failed to load user roles';
      }
    });
  }

  goToDV() {
    this.router.navigate([UrlConstants.DICHVU]);
  }

}
