import * as CryptoJS from 'crypto-js';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertController, LoadingController } from '@ionic/angular';
import { UrlConstants } from '../../core/constants/url.constant';
import { ValidatorConstants } from 'src/app/core/constants/validator.constants';
import { LoginService } from 'src/app/core/services/login.service';
import { AuthService } from 'src/app/core/services/auth.service';
<<<<<<< HEAD
import QrScanner from 'qr-scanner'; // Import thư viện QrScanner
import { Capacitor } from '@capacitor/core'; // Import Capacitor core để phát hiện nền tảng
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { firstValueFrom } from 'rxjs';
=======
import QrScanner from 'qr-scanner';
>>>>>>> d29039f321d24798f27a7c07dbfa6b302da24d83

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
<<<<<<< HEAD
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
  
=======
      this.qrScannerInstance = new QrScanner(this.videoElem.nativeElement, (result) => {
        console.log('Scanned result:', result);

        // Stop the QR scanner after getting the result
        this.qrScannerInstance.stop();

        // Decrypt the scanned QR data
        const decryptedData = this.decryptQrData(result.data);
        this.showScannedDataAlert(decryptedData);
      }, {
        onDecodeError: (error) => console.error('Error decoding QR code:', error),
        highlightScanRegion: true,
        highlightCodeOutline: true
      });

>>>>>>> d29039f321d24798f27a7c07dbfa6b302da24d83
      await this.qrScannerInstance.start();
    } catch (error) {
      console.error('Error scanning QR code:', error);
      this.showErrorAlert('Error scanning QR code. Please try again.');
    }
  }
<<<<<<< HEAD
  
  
  
  
=======

  decryptQrData(cipherText: string): string {
    // Decrypt the cipher text using CryptoJS AES decryption
    const decrypted = CryptoJS.AES.decrypt(cipherText, this.aesKey, {
      iv: this.aesIv,
      mode: CryptoJS.mode.CBC,
      padding: CryptoJS.pad.Pkcs7
    });
    return decrypted.toString(CryptoJS.enc.Utf8);
  }

  async showScannedDataAlert(scannedData: string) {
    const alert = await this.alertController.create({
      header: 'Mã QR đã quét',
      message: `Dữ liệu: ${scannedData}`,
      buttons: ['OK'],
    });

    await alert.present();
  }
>>>>>>> d29039f321d24798f27a7c07dbfa6b302da24d83

  async showErrorAlert(errorMessage: string) {
    const alert = await this.alertController.create({
      header: 'Lỗi',
      message: errorMessage,
      buttons: ['OK'],
    });

    await alert.present();
  }
}
