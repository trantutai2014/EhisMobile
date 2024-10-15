import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertController, LoadingController } from '@ionic/angular';
import { UrlConstants } from '../../core/constants/url.constant';
import QrScanner from 'qr-scanner';

import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AuthService } from '../../core/services/auth.service';
import { ValidatorConstants } from 'src/app/core/constants/validator.constants';
import { LoginService } from 'src/app/core/services/login.service';

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
  @ViewChild('video', { static: false }) videoElem!: ElementRef;
  qrScannerInstance!: QrScanner;
  private apiUrl = `${environment.BASE_API}/api/QRCode/`;
  cccd: string | undefined;
  message: any;


  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router,
    private loadingCtrl: LoadingController,
    private authService: AuthService,
    private alertController: AlertController,
    private http: HttpClient,
   
  ) {
    this.formData = this.fb.group({
      username: [null, [Validators.required, Validators.pattern(this.ValidatorConsts.v_username)]],
      password: [null, [Validators.required, Validators.pattern(this.ValidatorConsts.v_password)]],
    });
  }
  
  ngOnInit() {
   }

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
  
    try {
      const success = await this.authService.login(username, password);
      if (success) {
        this.router.navigate([UrlConstants.THONGTINHANHCHINH]);
        window.location.reload();
      } else {
        this.error = 'Đăng nhập không thành công';
      }
    } catch (err) {
      // this.error = err?.message || 'Đăng nhập không thành công';
    } finally {
      loading.dismiss();
    }
  }
  
  async loginqr() {
    try {
      this.qrScannerInstance = new QrScanner(this.videoElem.nativeElement, async (result) => {
        this.qrScannerInstance.stop();
        const code = result.data.toString();
        const response = await firstValueFrom(this.http.get<{ token: string, cccd: string }>(`${this.apiUrl}${code}`));
  
        if (response && response.token && response.cccd) {
          localStorage.setItem('token', response.token);
          localStorage.setItem('cccd', response.cccd);
          this.cccd = response.cccd;
          this.router.navigate([UrlConstants.THONGTINHANHCHINH.replace(':cccd', this.cccd)]);
        } else {
          this.showErrorAlert('Dữ liệu không hợp lệ từ máy chủ');
        }
      }, {
        highlightScanRegion: true,
        highlightCodeOutline: true,
      });
  
      await this.qrScannerInstance.start();
    } catch (error) {
      console.error('Error scanning QR code:', error);
      this.showErrorAlert('Có lỗi xảy ra khi quét mã QR. Vui lòng thử lại.');
    }
  }
  

  async showErrorAlert(errorMessage: string) {
    const alert = await this.alertController.create({
      header: 'Lỗi',
      message: errorMessage,
      buttons: ['OK'],
    });

    await alert.present();
  }
}
