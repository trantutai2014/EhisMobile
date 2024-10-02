import * as CryptoJS from 'crypto-js';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertController, LoadingController } from '@ionic/angular';
import { UrlConstants } from '../../core/constants/url.constant';
import { ValidatorConstants } from 'src/app/core/constants/validator.constants';
import { LoginService } from 'src/app/core/services/login.service';
import { AuthService } from 'src/app/core/services/auth.service';
import QrScanner from 'qr-scanner';
import { environment } from 'src/environments/environment.prod';

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
  private apiUrl = `${environment.BASE_API}/QRCode/`;
  cccd: string | undefined;

  // AES Key and IV (same as backend)
  private aesKey = CryptoJS.enc.Base64.parse('YFlCfJWXFeZ/NHyLhq0XYNT/Dd/mUpInFxtvWnkj84g=');
  private aesIv = CryptoJS.enc.Base64.parse('fZz5TQgfUHgS6lwT6q8Q8Q==');

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

    this.authService.login(username, password)
      .then((success: boolean) => {
        if (success) {
          this.router.navigate([UrlConstants.THONGTINHANHCHINH]);
        } else {
          this.error = 'Đăng nhập không thành công';
        }
      })
      .catch((err: any) => {
        this.error = err.error?.message || 'Đăng nhập không thành công';
      })
      .finally(() => {
        loading.dismiss();
      });
  }

  async loginqr() {
    try {
      this.qrScannerInstance = new QrScanner(this.videoElem.nativeElement, async (result) => {
        this.qrScannerInstance.stop();
        const cccd = result.data.toString();
        const response = await firstValueFrom(this.http.get<{ qrCodeData: any, token: string }>(`${this.apiUrl}${cccd}`));
        if (response) {
          localStorage.setItem('token', response.token);
          this.router.navigate([UrlConstants.THONGTINHANHCHINH.replace(':cccd', cccd)]);
        } else {
          this.showErrorAlert('No token received from the server');
        }
      }, {
        highlightScanRegion: true,
        highlightCodeOutline: true,
      });
  
      await this.qrScannerInstance.start();
    } catch (error) {
      console.error('Error scanning QR code:', error);
      this.showErrorAlert('Error scanning QR code. Please try again.');
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
