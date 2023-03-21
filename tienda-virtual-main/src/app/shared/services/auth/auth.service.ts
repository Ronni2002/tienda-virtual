import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../../models/login.model';
import { BaseService } from '../base/base.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService<Login> {
  constructor(private _http : HttpClient) {
    super(_http, 'Account');
   }

   IsLoggedIn(){
    return localStorage.getItem('token') != null;
   }
}
