import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { enviroment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BaseService<T> {
  public baseUrl: string;
  public headers: any;
  constructor(private http: HttpClient, @Inject('endpoint') endpoint: string) {
    this.baseUrl = `${enviroment.apiUrl}/${endpoint}`;
    this.headers = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });
    console.log(this.headers)
    console.log(localStorage.getItem('token'))
  }

  public post(obj: T, action = '') {
    return this.http.post<T>(`${this.baseUrl}/${action}`, obj, {headers: this.headers});
  }

  public get(action = '') {
    return this.http.get<T>(`${this.baseUrl}/${action}`, {headers: this.headers});
  }

  public getById(id: string) {
    return this.http.get<T>(`${this.baseUrl}/${id}`, { headers: this.headers });
  }

  public put(obj: T, action = '') {
    return this.http.put<T>(`${this.baseUrl}`, obj, {headers: this.headers});
  }

  public delete(obj: T, action = '') {
    return this.http.delete<T>(`${this.baseUrl}/${action}`, {headers: this.headers});
  }
}
