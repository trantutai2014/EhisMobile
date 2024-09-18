import { Injectable } from '@angular/core';
import * as moment from 'moment';
@Injectable({
    providedIn: 'root',
})
export class DateService {

    /**Format ngày giờ kiểu DD/MM*/
    formatdate_topart(date: any): string | null {
        let _date: Date = new Date();
        if (!date)
            return '';
        else if (date instanceof Date)
            _date = date;
        else if (date instanceof String || typeof date === 'string')
            _date = new Date(date.toString())
        return moment(date).format('MMYY');
    }

    /**Format ngày giờ kiểu DD/MM/YYYY HH:mm*/
    formatdate_ddmmyyyyhhmm(date: any): string | null {
        let _date: Date = new Date();
        if (!date)
            return '';
        else if (date instanceof Date)
            _date = date;
        else if (date instanceof String || typeof date === 'string')
            _date = new Date(date.toString())
        return moment(date).format('DD/MM/YYYY HH:mm');
    }
    /**Chuyển thành kiều ngày giờ của server
     * @date Ngày giờ client
     */
    formatdatetime_toserve(date: any): string | null {
        if (date && (date instanceof Date))
            return moment(date).format('YYYY-MM-DD[T]HH:mm');
        try {
            return moment(date).format('YYYY-MM-DD[T]HH:mm');
        }
        catch (ex) {
            console.log(ex)
            return null;
        }
    }
}