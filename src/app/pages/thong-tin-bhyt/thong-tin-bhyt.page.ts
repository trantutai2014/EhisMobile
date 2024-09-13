import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';

@Component({
  selector: 'app-thogntinbhyt',
  templateUrl: './thong-tin-bhyt.page.html',
  styleUrls: ['./thong-tin-bhyt.page.scss'],
})
export class ThongTinBHYTPage implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }
  goToDV() {
    this.router.navigate([UrlConstants.DICHVU]);
  }

}