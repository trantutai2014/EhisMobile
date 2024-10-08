import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { firstValueFrom, Observable, throwError, map, catchError } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: string | null = null;

  constructor(private http: HttpClient, private router: Router) {}

  async login(username: string, password: string): Promise<boolean> {
    const body = { username, password };

    try {
      const response = await firstValueFrom(this.http.post<{ token: string, refreshToken: string }>(`${environment.BASE_API}/api/DangNhap`, body));
      
      if (response && response.token) {
        this.token = response.token;
        localStorage.setItem('token', this.token); // Lưu access token
        localStorage.setItem('refreshToken', response.refreshToken); // Lưu refresh token
        return true;
      }

      return false;
    } catch (error) {
      console.error("Error during login:", error);
      return false;
    }
  }

  getToken(): string | null {
    return localStorage.getItem('token'); // Lấy access token từ localStorage
  }

  logout() {
    this.token = null;
    localStorage.removeItem('token'); // Xóa token khi đăng xuất
    localStorage.removeItem('refreshToken'); // Xóa refresh token
    this.router.navigate(['/login']);
  }

  refreshToken(): Observable<any> {
    const refreshToken = localStorage.getItem('refreshToken');
    if (!refreshToken) {
      console.error('No refresh token found');
      this.logout(); // Đăng xuất nếu không có refresh token
      return throwError(() => new Error('No refresh token'));
    }

    return this.http.post<any>(`${environment.BASE_API}/api/Auth/refresh`, { refreshToken })
      .pipe(
        map(response => {
          localStorage.setItem('token', response.accessToken); // Lưu token mới
          localStorage.setItem('refreshToken', response.refreshToken); // Lưu refresh token mới
          return response;
        }),
        catchError(error => {
          console.error('Error refreshing token:', error);
          this.logout(); // Đăng xuất nếu refresh token không hợp lệ
          return throwError(() => new Error('Refresh token failed'));
        })
      );
  }
}
