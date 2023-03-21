import { HttpClient } from '@angular/common/http';
import { Product } from '../../models/product.model';
import { BaseService } from './../base/base.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService<Product> {

  constructor(private _http : HttpClient) {
    super(_http, 'Products');
   }
}
