import { Injectable } from '@angular/core';
import {  CanActivate, Router} from '@angular/router';
import { LoginService } from '../services/login.service';
import { UrlConstants } from '../constants/url.constant';
import { AuthService } from '../services/auth.service';

@Injectable({
    providedIn: 'root',
  })
  export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router) {}
  
    canActivate(): boolean {
      const isLoggedIn = this.authService.getToken();
      console.log('isLoggedIn:', isLoggedIn); // Kiểm tra trạng thái đăng nhập từ service
      if (!isLoggedIn) {
        this.router.navigate([UrlConstants.LOGIN]);
        return false;
      }
      return true;
    }
  }
  