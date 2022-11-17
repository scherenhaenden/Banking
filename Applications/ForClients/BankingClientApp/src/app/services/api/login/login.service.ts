import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiBaseService } from '../generic/api-base.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private apiBaseService: ApiBaseService) { }

  public async loginCustomer(email: string, password: string): Promise<object> {

    const headers = new HttpHeaders({
      'Content-Type':  'application/json',
    });

    const AuthenticateRequest = {
      Username:email, Password:password};
    // Call API to login
    const result = await this.apiBaseService.post<any>('/Login/authenticate', AuthenticateRequest, headers);
    return result;
  }

  public async loginEmployee(employeeId: string, password: string): Promise<object> {

    const headers = new HttpHeaders({
      'Content-Type':  'application/json',
    });

    // Create query string
    const query = new HttpParams()
      .set('employeeId', employeeId)
      .set('password', password);



    // Call API to login
    const result = await this.apiBaseService.get<any>('/Login/LoginEmployees', query, headers);
    return result;
  }
}
