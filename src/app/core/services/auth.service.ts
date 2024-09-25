import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: string | null = null;

  constructor(private http: HttpClient, private router: Router) {}

  async login(username: string, password: string): Promise<boolean> {
    const body = { username, password };
  
    try {
      const response = await firstValueFrom(this.http.post<{ token: string }>(`https://localhost:7170/api/DangNhap`, body));
      
      // Nếu nhận được token từ phản hồi
      if (response.token) {
        this.token = response.token;
        localStorage.setItem('token', this.token); // Lưu token vào localStorage
        return true; // Đăng nhập thành công
      }
  
      return false; // Nếu không có token, trả về false
    } catch (error) {
      console.error("Error during login:", error);
      return false; // Xử lý lỗi và trả về false
    }
  }
  
  getToken(): string | null {
    return localStorage.getItem('token'); // Lấy token từ localStorage
  }

  logout() {
    this.token = null;
    localStorage.removeItem('token'); // Xóa token khi đăng xuất
    this.router.navigate(['/thong-tin-hanh-chinh']);
  }
}
