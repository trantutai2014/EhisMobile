import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class UserRoleService {
  private apiUrl = `${environment.BASE_API}/UserRoles/GetAll`; // URL API được lấy từ environment

  constructor(private http: HttpClient) {}

  getUserRoles(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
