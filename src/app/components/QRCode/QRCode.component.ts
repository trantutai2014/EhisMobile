import { Component, OnInit, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-qr',
  templateUrl: './QRCode.component.html',
  styleUrls: ['./QRCode.component.scss'],
})
export class QrPage implements OnInit, OnDestroy {

  constructor() { }

  qrString: string = '';
  intervalId: any;
  scanResult: any;

  ngOnInit() {
    this.updateQRCode(); // Cập nhật mã QR chỉ một lần
  }

  ngOnDestroy() {
    // Dọn dẹp nếu có các interval hoặc tài nguyên cần dừng lại
    if (this.intervalId) {
      clearInterval(this.intervalId);
    }
  }

  updateQRCode() {
    this.qrString = '' + new Date().toISOString(); // Thiết lập mã QR chỉ một lần
    this.scanResult = this.qrString;
  }
}
