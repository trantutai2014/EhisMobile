import { Injectable } from "@angular/core";


@Injectable({
    providedIn: 'root',
})

export class CccdService {
    private cccd: string  = '';

    constructor() {

    }

    // luu gia tri CCCD
    setCccd(value: string) {
        this.cccd = value;

    }

    //lay gia tri CCCD
    getCccd(): string{
        return this.cccd;
    }
}
