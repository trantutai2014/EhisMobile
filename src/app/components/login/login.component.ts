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

  // AES Key and IV (same as backend)
  private aesKey = CryptoJS.enc.Base64.parse('YFlCfJWXFeZ/NHyLhq0XYNT/Dd/mUpInFxtvWnkj84g=');
  private aesIv = CryptoJS.enc.Base64.parse('fZz5TQgfUHgS6lwT6q8Q8Q==');

  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router,
    private loadingCtrl: LoadingController,
    private authService: AuthService,
    private alertController: AlertController
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

      await this.qrScannerInstance.start();
    } catch (error) {
      console.error('Lỗi khi quét mã QR:', error);
      this.showErrorAlert('Lỗi khi quét mã QR. Vui lòng thử lại.');
    }
  }

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

  async showErrorAlert(errorMessage: string) {
    const alert = await this.alertController.create({
      header: 'Lỗi',
      message: errorMessage,
      buttons: ['OK'],
    });

    await alert.present();
  }
}
