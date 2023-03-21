import { HttpClient } from '@angular/common/http';
import { BaseService } from './../base/base.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MockService extends BaseService<any> {
  constructor(private _http: HttpClient) {
    super(_http, 'users');
    // this.baseUrl = 'https://reqres.in/api/users';
  }
}
