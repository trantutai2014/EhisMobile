import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';


@Component({
  selector: 'app-pay',
  templateUrl: './pay.page.html',
  styleUrls: ['./pay.page.scss'],
})
export class PayPage implements OnInit {
  bill: { name: string, quantity: number }[] = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    // Truy cập dữ liệu từ state
    const navigation = this.router.getCurrentNavigation();
    if (navigation && navigation.extras && navigation.extras.state) {
      const state = navigation.extras.state as { bill: string };
      if (state.bill) {
        try {
          this.bill = JSON.parse(state.bill);
        } catch (e) {
          console.error('Error parsing bill data:', e);
        }
      }
    }
  }

  confirm() {

  }

  huy() {
    this.router.navigate([UrlConstants.SEARCH], {
      replaceUrl: true // Thay thế URL hiện tại mà không giữ lại lịch sử
    });
  }
}
