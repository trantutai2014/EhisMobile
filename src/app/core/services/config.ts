import { Injectable } from '@angular/core';
import { SystemConstants } from '../constants/system.constants';
import { environment } from 'src/environments/environment';
import { LoginService } from './login.service';

@Injectable()
export class ConfigService {
    constructor(private loginService: LoginService) { }

    loadConfig() {
        const noiLamViec = localStorage.getItem(SystemConstants.MABV) || undefined;
        const benhVien = noiLamViec && environment.NOILAMVIEC.find(s => s.id == noiLamViec);
        if (benhVien) {
            environment.BASE_API = benhVien.url;
        }
        else {
            this.loginService.logout();
        }
    }
}
