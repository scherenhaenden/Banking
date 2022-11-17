import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiBaseService {

  constructor(private http: HttpClient) { }

  // Write method to execute a GET request WITH query parameters
  public async get<T>(route: string, query?: HttpParams, headers?: HttpHeaders, host?: string): Promise<T> {
    const httpOptionsNew = {
      headers: headers
    };
    const url = host ? host + route : environment.apiHost + route;

    // Create call http get with url and query parameters and headers
    return lastValueFrom(this.http.get<T>(url, { params: query, headers: headers }));
  }

/*public add(a: number, b: number, c: number): number;
  public add(a: number, b: number): any;
  public add(a: string, b: string): any;

  public add(a: any, b: any, c?: any): any|number  {
    if (c) {
      return a + c;
    }
    if (typeof a === 'string') {
      return `a is ${a}, b is ${b}`;
    } else {
      return a + b;
    }
  }*/

  // Write method to execute a POST request
  public async post<T>(route: string, body: any, headers?: HttpHeaders, host?: string,): Promise<T> {
    const httpOptionsNew = {
      headers: headers
    };

    const url = host ? host + route : environment.apiHost + route;

    return lastValueFrom(this.http.post<T>(url, body, httpOptionsNew));
  }


  // Write method to execute a PUT request
  public async put(route: string, body: any, host?: string): Promise<any> {

      const httpOptionsNew = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
          //Authorization: 'Bearer ' + localStorage.getItem('token')
        }),
      };

        const url = host ? host + route : environment.apiHost + route;
        return lastValueFrom(this.http.put(url, body));
    }
}
