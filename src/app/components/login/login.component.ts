import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertController, LoadingController } from '@ionic/angular';
import { UrlConstants } from '../../core/constants/url.constant';
import { ValidatorConstants } from 'src/app/core/constants/validator.constants';
import { LoginService } from 'src/app/core/services/login.service';
import { AuthService } from 'src/app/core/services/auth.service';
import QrScanner from 'qr-scanner';
import { Camera, CameraResultType } from '@capacitor/camera'; // Import Capacitor Camera plugin
import { Capacitor } from '@capacitor/core'; // Import Capacitor core for platform detection

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
      // Check if we are running on a native platform (Android/iOS) or web
      if (Capacitor.isNativePlatform()) {
        // Handle QR code scanning on native platforms using Capacitor Camera
        const cameraPermission = await Camera.requestPermissions();
        if (cameraPermission.camera === 'granted') {
          const image = await Camera.getPhoto({
            quality: 90,
            allowEditing: false,
            resultType: CameraResultType.Base64, // or use CameraResultType.Uri if needed
          });

          // Handle the image data here, e.g., send it to a server for processing.
          this.showScannedDataAlert(image.base64String!); // Show the base64 string result
        } else {
          this.showErrorAlert('Camera permission is required to scan QR codes.');
        }
      } else {
        // Handle QR code scanning on the web using the QrScanner library
        this.qrScannerInstance = new QrScanner(this.videoElem.nativeElement, (result) => {
          console.log('Scanned result:', result);
          this.qrScannerInstance.stop();
          this.showScannedDataAlert(result);
        });

        // Start scanning the QR code
        await this.qrScannerInstance.start();
      }
    } catch (error) {
      console.error('Error scanning QR code:', error);
      this.showErrorAlert('Error scanning QR code. Please try again.');
    }
  }

  // Function to show the alert with scanned QR code data
  async showScannedDataAlert(scannedData: string) {
    const alert = await this.alertController.create({
      header: 'Scanned QR Code',
      message: `Data: ${scannedData}`,
      buttons: ['OK'],
    });

    await alert.present();
  }

  // Function to show an error alert
  async showErrorAlert(errorMessage: string) {
    const alert = await this.alertController.create({
      header: 'Error',
      message: errorMessage,
      buttons: ['OK'],
    });

    await alert.present();
  }
}
