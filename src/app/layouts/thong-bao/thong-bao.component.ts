import { Component, ViewChild } from '@angular/core';
import { IonModal } from '@ionic/angular';
import { OverlayEventDetail } from '@ionic/core/components';

@Component({
  selector: 'app-thongbao',
  templateUrl: 'thong-bao.component.html',
})
export class ThongBaoComponent {
  @ViewChild(IonModal)
    modal!: IonModal;

  cancel() {
    this.modal.dismiss(null, 'cancel');
  }
}