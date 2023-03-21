import { ProductService } from './../../../../shared/services/product/product.service';
import { Product } from './../../../../shared/models/product.model';
import { Component } from '@angular/core';
import { tap } from 'rxjs';

interface Person {
  key: string;
  name: string;
  age: number;
  address: string;
}

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss'],
})
export class ProductsListComponent {
  listOfData: any;

  constructor(private service: ProductService) {
    this.getProducts();
  }

  public getProducts() {
    this.service
      .get()
      .pipe(tap((response) => {
        this.listOfData = response;
        console.log(response)
      }))
      .subscribe();
  }

}
