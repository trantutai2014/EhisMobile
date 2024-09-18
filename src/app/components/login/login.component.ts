import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoadingController } from '@ionic/angular';
import { UrlConstants } from '../../core/constants/url.constant';
import { ValidatorConstants } from 'src/app/core/constants/validator.constants';
import { LoginService } from 'src/app/core/services/login.service';
import { SystemConstants } from 'src/app/core/constants/system.constants';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  formData: FormGroup;
  public ValidatorConsts = ValidatorConstants;
  loading: boolean = false;
  error: string | undefined;
  private headers = new HttpHeaders();

  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router,
    private loadingCtrl: LoadingController,
    private http: HttpClient,
  ) {
    this.formData = this.fb.group({
      username: [null, [Validators.required, Validators.pattern(this.ValidatorConsts.v_username)]],
      password: [null, [Validators.required, Validators.pattern(this.ValidatorConsts.v_password)]],
    });
  }

  ngOnInit() { }

  async login() {
    if (this.formData.invalid) {
      this.formData.markAllAsTouched();
      return;
    }
  
    const { username, password } = this.formData.value;
    const loading = await this.loadingCtrl.create({
      message: 'Đang tải...',
    });
    await loading.present();
  
    this.loginService.login(username, password)
      .then((response: any) => {
        if (response && response.message === 'Đăng nhập thành công') {
          this.router.navigate([UrlConstants.TRANGCHU]);
        } else {
          this.error = 'Đăng nhập không thành công';
        }
      })
      .catch((err: any) => {
        this.error = err.error.message || 'Đăng nhập không thành công';
      })
      .finally(() => {
        loading.dismiss();
      });
  }

  loginqr() {
    this.router.navigate([UrlConstants.LOGINQR]);
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

saveToken(token: any) {
    localStorage.setItem(SystemConstants.CURRENT_USER, JSON.stringify(token));
    const userlogin = this.getLoggedInUser();
    const expires = new Date(userlogin.exp * 1000);
    console.warn('Token expires at', expires);
}

//#region refresh token
refreshToken(token:any) {
return this.http.post(environment.BASE_API + 'refreshtoken', {refreshToken: token},  { headers: this.headers });
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