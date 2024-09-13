import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dichvu',
  templateUrl: './dichvu.page.html',
  styleUrls: ['./dichvu.page.scss'],
})
export class DichvuPage implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  onServiceClick(service: string) {
    // Handle the click event here
    console.log('Service clicked:', service);
    // You can navigate to another page, open a modal, or perform any action
  }
}
