import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class BackPageService {
    constructor(private router: Router) { }
    public getActiveUrl():String
    {
        return this.router.url;
    }
    public backPage(backUrl: string) {
        const url = this.sortParams(backUrl);
        this.router.navigate([url.path], { queryParams: url.params });
    }
    private sortParams(url: string): any {

        const _url = url.split('?')[0];
        const queryParams = url.split('?')[1] || '';
        const params = queryParams.split('&');
        let pair: string[] = [];
        let data: any = {};

        params.forEach((d) => {
            if (d && d != '') {
                pair = d.split('=');
                data[`${pair[0]}`] = decodeURIComponent(pair[1]);
            }
        });
        return { path: _url, params: data };
    }
}
