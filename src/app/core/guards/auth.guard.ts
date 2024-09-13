// import { Injectable } from '@angular/core';
// import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
// import { SystemConstants } from '../constants/system.constants';
// import { UrlConstants } from '../constants/url.constant';

// @Injectable()
// export class AuthGuard implements CanActivate {
//     constructor(private router: Router) { }

//     canActivate(_activateRoute: ActivatedRouteSnapshot, routerState: RouterStateSnapshot) {
//         if (localStorage.getItem(SystemConstants.CURRENT_USER)) {
//             return true;
//         } else {
//             this.router.navigate([UrlConstants.LOGINACC], {
//                 queryParams: {
//                     returnUrl: routerState.url
//                 }
//             });

//             return false;
//         }
//     }
// }