import { Component, OnInit } from '@angular/core';
import { profiles } from 'src/data/profile';
import { Router } from '@angular/router';
import { UrlConstants } from '../../core/constants/url.constant';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit {

  items: any[] = [];
  itemModel: any = {};


  constructor(private router: Router) { }

  ngOnInit() {
    this.items = [...profiles];
  }

  goToProFile() {
    this.router.navigate([UrlConstants.PROFILE]);
  }

  goToMain() {
    this.router.navigate([UrlConstants.MAIN]);
  }

  goToSetting() {
    this.router.navigate([UrlConstants.SETTING]);
  }

  goToHistory() {
    this.router.navigate([UrlConstants.HISTORY]);
  }

}
