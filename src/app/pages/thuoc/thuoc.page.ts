import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NavController, ToastController } from '@ionic/angular';
import { itemsWithPrices } from 'src/data/profile';

@Component({
  selector: 'app-thuoc',
  templateUrl: './thuoc.page.html',
  styleUrls: ['./thuoc.page.scss'],
})
export class ThuocPage {
  items = itemsWithPrices; // Sử dụng dữ liệu từ tệp
  displayedItems = this.items.slice(0, 5); // Hiển thị 5 mục đầu tiên
  selectedItems: { [key: string]: number } = {};
  selectedItemKeys: string[] = [];
  maxItems = 10;

  constructor(
    private router: Router,
    private navCtrl: NavController,
    private toastController: ToastController
  ) { }

  onSearch(event: any) {
    const searchTerm = event.target.value.toLowerCase();
    this.displayedItems = this.items.filter(item =>
      item.name.toLowerCase().includes(searchTerm)
    );
  }

  async addToSelected(item: any) {
    if (this.selectedItemKeys.length >= this.maxItems && !this.selectedItems[item.name]) {
      await this.showToast('Số lượng thuốc đã chọn tối đa là 10.');
      return;
    }

    if (this.selectedItems[item.name]) {
      this.selectedItems[item.name]++;
    } else {
      this.selectedItems[item.name] = 1;
      this.selectedItemKeys.push(item.name);
    }
  }

  removeItem(item: string) {
    // Remove item from selectedItems
    delete this.selectedItems[item];

    // Remove item from selectedItemKeys
    this.selectedItemKeys = this.selectedItemKeys.filter(key => key !== item);
  }


  createBill() {
    console.log('Creating bill with items:', this.selectedItems);
  }

  trackByIndex(index: number): number {
    return index;
  }

  private async showToast(message: string) {
    const toast = await this.toastController.create({
      message: message,
      duration: 2000, // Thời gian hiển thị toast, tính bằng mili giây
      position: 'bottom',
      color: 'danger' // Màu của toast
    });
    toast.present();
  }
}
