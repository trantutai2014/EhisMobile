import { Component, OnInit, OnDestroy } from '@angular/core';



@Component({
  selector: 'app-loginQR',
  templateUrl: 'loginQR.page.html',
  styleUrls: ['loginQR.page.scss'],
})
export class LoginQR implements OnInit, OnDestroy {
  qrString: string = '';
  intervalId: any;
  scanResult: any;

  private secretKey: string = 'your-very-secure-secret';



  ngOnInit() {
    this.startQRCodeUpdate();
  }

  ngOnDestroy() {
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }

  startQRCodeUpdate() {
    this.updateQRCode();
    this.intervalId = setInterval(() => {
      this.updateQRCode();
    }, 1000);
  }

  updateQRCode() {
    const payload = { timestamp: new Date().toISOString() };
    const header = { alg: 'HS256', typ: 'JWT' };


    // Generate JWT
    const token = btoa(JSON.stringify(header)) + '.' + btoa(JSON.stringify(payload));

    this.qrString = token;
    this.scanResult = token;
  }

  //   updateQRCode() {
  //   const payload = { timestamp: new Date().toISOString() };
  //   const token = jwt.sign(payload, this.secretKey, { algorithm: 'HS256' });

  //   this.qrString = token;
  // }

}
