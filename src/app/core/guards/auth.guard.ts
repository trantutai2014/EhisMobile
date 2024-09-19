import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { SystemConstants } from '../constants/system.constants';
import { UrlConstants } from '../constants/url.constant';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router) { }

    canActivate(_activateRoute: ActivatedRouteSnapshot, routerState: RouterStateSnapshot) {
        // Kiểm tra nếu có thông tin người dùng trong localStorage
        if (localStorage.getItem(SystemConstants.CURRENT_USER)) {
            return true; // Người dùng đã đăng nhập
        } else {
            // Chuyển hướng tới trang đăng nhập kèm theo URL người dùng đang cố gắng truy cập
            this.router.navigate([UrlConstants.LOGIN], {
                queryParams: { returnUrl: routerState.url }
            });
            return false; // Không cho phép truy cập
        }
    }
}
