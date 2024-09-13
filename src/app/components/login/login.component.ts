import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorConstants } from 'src/app/core/constants/validator.contants';
import { UrlConstants } from 'src/app/core/constants/url.constant';




@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  error: string | undefined;

  isLogin = {
    username: "",
    password: "",
  };
  public ValidatorConsts = ValidatorConstants;
  formData: FormGroup;

  type: boolean = true;

  constructor(
    private router: Router,
  ) {
    this.formData = new FormGroup({
      userName: new FormControl(null, [Validators.required, Validators.pattern(this.ValidatorConsts.v_username)]),
      password: new FormControl(null, [Validators.required, Validators.pattern(this.ValidatorConsts.v_password)])
    });
  }

  ngOnInit() {
  }

  login() {
    this.router.navigate([UrlConstants.TRANGCHU]);
  }

  loginqr() {
    this.router.navigate([UrlConstants.LOGINQR]);
  }

  showPassword() {
    this.type = !this.type; 
  }
  goToForget() {
    this.router.navigate([UrlConstants.FORGET]);
  }
}

