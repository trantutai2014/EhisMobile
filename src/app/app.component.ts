import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators'; // For handling errors
import { UrlConstants } from './core/constants/url.constant';
import { of } from 'rxjs';

interface Data {
  // Define the expected structure of your data here (optional)
}

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent implements OnInit {
  posts: Data[] = []; // Typed array to prevent type errors
  isLoading = false; // Flag for loading state
  cccd: any;

  // Inject HttpClient via constructor
  constructor(private http: HttpClient) {}

  ngOnInit() {
    // Optional: Initial data fetch if needed
  }

}