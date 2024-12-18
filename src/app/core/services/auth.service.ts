import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, firstValueFrom, tap } from 'rxjs';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: string | null = null;
  private refreshTokenInProgress = false;
  private accessTokenSubject: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null);

  constructor(private http: HttpClient, private router: Router) { }

  async login(username: string, password: string): Promise<boolean> {
    const body = { username, password };

    try {
      const response = await firstValueFrom(this.http.post<{ token: string }>(environment.BASE_API+`/api/DangNhap`, body));

      if (response.token) {
        this.token = response.token;
        localStorage.setItem('token', this.token);
        return true;
      }

      return false;
    } catch (error) {
      console.error("Error during login:", error);
      return false;
    }
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  logout() {
    this.token = null;
    localStorage.removeItem('token');
    localStorage.removeItem('cccd');
    this.router.navigate(['/login']);
  }

  async getUserById(userId: string): Promise<any> {
    try {
      const user = await firstValueFrom(this.http.get<any>(`https://localhost:7170/api/Users/${userId}`));
      return user;
    } catch (error) {
      console.error("Error fetching user by ID:", error);
      throw error;
    }
  }

  getRefreshToken(): string | null {
    return localStorage.getItem('refreshToken');
  }

  saveTokens(accessToken: string, refreshToken: string): void {
    localStorage.setItem('accessToken', accessToken);
    localStorage.setItem('refreshToken', refreshToken);
  }

  refreshToken(): Observable<any> {
    return this.http.post('/api/auth/refresh-token', {
      refreshToken: this.getRefreshToken()
    }).pipe(
      tap((response: any) => {
        this.saveTokens(response.accessToken, response.refreshToken);
        this.accessTokenSubject.next(response.accessToken);
      })
    );
  }

  isRefreshTokenInProgress(): boolean {
    return this.refreshTokenInProgress;
  }

  setRefreshTokenInProgress(status: boolean): void {
    this.refreshTokenInProgress = status;
  }

  getAccessTokenSubject(): BehaviorSubject<string | null> {
    return this.accessTokenSubject;
  }
}

