import { Inject, Injectable, Injector } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SystemConstants } from '../constants/system.constants';
import { Router } from '@angular/router';
import { UrlConstants } from '../constants/url.constant';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class LoginService {
    private headers = new HttpHeaders();
    constructor(
        @Inject(Injector) private injector: Injector,
        private router: Router,
        private http: HttpClient,
    ) {
        this.headers = this.headers.set('Content-Type', 'application/json');
    }

    async login(userName: string, password: string) {
        const body = { userName, password };
        const promise = new Promise((resolve, reject) => {
            this.http.post(environment.BASE_API + '/api/auth', body, { headers: this.headers })
                .subscribe((response: any) => {
                    this.logout();
                    this.saveToken(response);
                    resolve(true);
                }, error => {
                    reject(error);
                });
        });
        return await promise;
    }

    logout() {
        localStorage.removeItem(SystemConstants.CURRENT_USER);
        this.router.navigate([UrlConstants.LOGIN]);
    }

    isUserAuthenticated() {
        return localStorage.getItem(SystemConstants.CURRENT_USER) != null;
    }

    getLoggedInUser() {
        if (!this.isUserAuthenticated()) return null;
        let obj = JSON.parse(localStorage.getItem(SystemConstants.CURRENT_USER) || '');
        const decodedToken = this.decodeJwt(obj.token);
        const user = Object.assign({}, obj, decodedToken.payload);
        return user;
    }

    getMaBacSi() {
        const user = this.getLoggedInUser();
        if (user && user.mabs != '')
            return user.mabs;
        return null;
    }

    saveToken(token: any) {
        localStorage.setItem(SystemConstants.CURRENT_USER, JSON.stringify(token));
        const userlogin = this.getLoggedInUser();
        const expires = new Date(userlogin.exp * 1000);
        console.warn('Token expires at', expires);
    }

    //#region refresh token
    refreshToken(token: any) {
        return this.http.post(environment.BASE_API + 'refreshtoken', { refreshToken: token }, { headers: this.headers });
    }
    //#endregion refresh token

    //#region helper method
    private decodeJwt(token: any) {
        const stringSplit = token.split('.');
        const tokenObject: any = {};
        tokenObject.raw = tokenObject;
        tokenObject.header = JSON.parse(this.urlBase64Decode(stringSplit[0]));
        tokenObject.payload = JSON.parse(this.urlBase64Decode(stringSplit[1]));

        return (tokenObject);
    }

    private urlBase64Decode(str: any) {
        let output = str.replace(/-/g, '+').replace(/_/g, '/');
        switch (output.length % 4) {
            case 0:
                break;
            case 2:
                output += '==';
                break;
            case 3:
                output += '=';
                break;
            default:
                throw new Error('Illegal base64url string!');
        }

        const result = window.atob(output);
        try {
            return decodeURIComponent(escape(result));
        } catch (err) {
            return result;
        }
    }
    //#endregion helper method
}
