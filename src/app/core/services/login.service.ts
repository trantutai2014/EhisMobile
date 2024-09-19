import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SystemConstants } from '../constants/system.constants';
import { Router } from '@angular/router';
import { UrlConstants } from '../constants/url.constant';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private headers = new HttpHeaders();

  constructor(private http: HttpClient, private router: Router) {
    this.headers = this.headers.set('Content-Type', 'application/json');
  }

  async login(username: string, password: string): Promise<any> {
    const body = { username, password };
    try {
      const response: any = await this.http.post(environment.BASE_API + '/api/DangNhap', body, { headers: this.headers }).toPromise();
      if (response.message === 'Đăng nhập thành công') {
        localStorage.setItem(SystemConstants.CURRENT_USER, JSON.stringify(response));
        return true;
      }
      return false;
    } catch (error: any) {
      if (error instanceof HttpErrorResponse && error.status === 500) {
        console.error('Server error:', error.error.message || 'Internal Server Error');
      } else {
        console.error('Unexpected error:', error);
      }
      this.logout();
      throw error;
    }
  }

  logout() {
    localStorage.removeItem(SystemConstants.CURRENT_USER);
    this.router.navigate([UrlConstants.LOGIN]);
  }

  isLoggedIn(): boolean {
    return localStorage.getItem(SystemConstants.CURRENT_USER) !== null;
  }
}
