import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertController, LoadingController } from '@ionic/angular';
import { UrlConstants } from '../../core/constants/url.constant';
import { ValidatorConstants } from 'src/app/core/constants/validator.constants';
import { LoginService } from 'src/app/core/services/login.service';
import { AuthService } from 'src/app/core/services/auth.service';
import QrScanner from 'qr-scanner'; // Import thư viện QrScanner
import { Capacitor } from '@capacitor/core'; // Import Capacitor core để phát hiện nền tảng

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
  @ViewChild('video', { static: false }) videoElem!: ElementRef; // Liên kết phần tử video trong template
  qrScannerInstance!: QrScanner;

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
      // Khởi tạo QR scanner với phần tử video
      this.qrScannerInstance = new QrScanner(this.videoElem.nativeElement, (result) => {
        console.log('Scanned result:', result);

        // Dừng scanner sau khi quét thành công
        this.qrScannerInstance.stop();

        // Hiển thị kết quả mã QR đã quét trong một alert
        this.showScannedDataAlert(result.data); // Lấy thuộc tính 'data' từ result
      }, {
        onDecodeError: (error) => console.error('Error decoding QR code:', error),
        highlightScanRegion: true,  // Đánh dấu vùng quét mã QR
        highlightCodeOutline: true  // Đánh dấu mã QR đã phát hiện
      });

      // Bắt đầu quá trình quét mã QR từ camera
      await this.qrScannerInstance.start();
    } catch (error) {
      console.error('Lỗi khi quét mã QR:', error);
      this.showErrorAlert('Lỗi khi quét mã QR. Vui lòng thử lại.');
    }
  }


  // Hàm hiển thị cảnh báo với dữ liệu mã QR đã quét
  async showScannedDataAlert(scannedData: string) {
    const alert = await this.alertController.create({
      header: 'Mã QR đã quét',
      message: `Dữ liệu: ${scannedData}`,
      buttons: ['OK'],
    });

    await alert.present();
  }

  // Hàm hiển thị cảnh báo lỗi
  async showErrorAlert(errorMessage: string) {
    const alert = await this.alertController.create({
      header: 'Lỗi',
      message: errorMessage,
      buttons: ['OK'],
    });

    await alert.present();
  }
}
