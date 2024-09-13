import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/core/constants/url.constant';

@Component({
  selector: 'app-dotkham',
  templateUrl: './ds-dot-kham.page.html',
  styleUrls: ['./ds-dot-kham.page.scss'],
})
export class DotkhamPage implements OnInit {
  

  constructor(private router: Router) { }

  ngOnInit() {
  }
  goToDV() {
    this.router.navigate([UrlConstants.DICHVU]);
  }

}
