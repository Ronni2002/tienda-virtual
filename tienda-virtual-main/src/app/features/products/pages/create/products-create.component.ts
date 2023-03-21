import { ProductService } from './../../../../shared/services/product/product.service';
import { Product } from './../../../../shared/models/product.model';
import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { catchError, tap } from 'rxjs';
import { v4 as uuidv4 } from 'uuid';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-products-create',
  templateUrl: './products-create.component.html',
  styleUrls: ['./products-create.component.scss'],
})
export class ProductsCreateComponent {
  productForm!: FormGroup;
  isUpdatedForm: boolean = false;
  public product: Product = {
    id: 'f51f8c7d-982d-46df-9ea9-5368d7d46112',
    name: 'Gorra',
    marca: 'Nike',
    productByPrices: [
      {
        id: 'ebf039d7-45c6-4965-8c2e-e7425f5bf5d5',
        productId: 'f51f8c7d-982d-46df-9ea9-5368d7d46112',
        color: 'Rojo',
        cost: 15,
      },
      {
        id: '4e4f9b02-b81d-4ad6-8e7f-bb25aef8137d',
        productId: 'f51f8c7d-982d-46df-9ea9-5368d7d46112',
        color: 'Negro',
        cost: 12,
      },
      {
        id: '102742c1-e2d2-45c2-a8df-9f93c59ec33a',
        productId: 'f51f8c7d-982d-46df-9ea9-5368d7d46112',
        color: 'Verde',
        cost: 14,
      },
      {
        id: 'ce106e81-909f-4681-a880-8d7b26a6fbbc',
        productId: 'f51f8c7d-982d-46df-9ea9-5368d7d46112',
        color: 'Azul',
        cost: 13,
      },
    ],
  };
  public id: string = '';

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    this.activatedRoute.params.subscribe(({id})=> this.id = id );
  }

  ngOnInit(): void {
    this.setForm();
    this.setFormValues();
  }

  public setFormValues() {
    if (this.router.url.includes('update')) {
      this.isUpdatedForm = true;

      const itemForms = this.product.productByPrices.map((item) =>
        this.fb.group({
          color: [item.color],
          cost: [item.cost],
        })
      );

      itemForms.forEach((itemForm) => this.productByPrices.push(itemForm));
      this.productByPrices.removeAt(0);
    }
  }

  private setForm() {
    this.productForm = this.fb.group({
      name: [
        this.isUpdatedForm ? 'this.product.name' : null,
        [Validators.required],
      ],
      marca: [
        this.isUpdatedForm ? 'this.product.marca' : null,
        [Validators.required],
      ],
      productByPrices: this.isUpdatedForm
        ? null
        : this.fb.array([this.newproductByPrices()]),
    });
  }

  public saveOrUpdate() {
    if (this.isUpdatedForm) {
      this.updateProduct()
    } else this.submitForm();

  }

  public submitForm(): void {
    if (this.productForm.valid) {
      const product: Product = this.formatProductBody(this.productForm.value);
      this.productService
        .post(product)
        .pipe(
          tap(() => this.router.navigate(['/products/list'])),
          catchError(async (err) => console.log(err))
        )
        .subscribe();
    } else {
      Object.values(this.productForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  public updateProduct(): void {
    if (this.productForm.valid) {
      const product: Product = this.formatProductBody(this.productForm.value);
      const body = {...product,
        id: this.id,
        productByPrices: product.productByPrices.map((product)=> ({
          ...product,
          productId: this.id
        }))}
      this.productService
        .put(body)
        .pipe(
          tap((response) => (console.log(response), this.router.navigate(['/products/list']))),
          catchError(async (err) => console.log(err))
        )
        .subscribe();
    } else {
      Object.values(this.productForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  private formatProductBody(product: Product) {
    const productId = uuidv4();
    return {
      ...product,
      id: productId,
      productByPrices: product.productByPrices.map((product: any) => ({
        ...product,
        cost: Number(product.cost),
        id: uuidv4(),
        productId,
      })),
    };
  }

  private newproductByPrices(): FormGroup {
    return this.fb.group({
      color: [null, [Validators.required]],
      cost: [null, [Validators.required]],
    });
  }

  public get productByPrices(): FormArray {
    return this.productForm.get('productByPrices') as FormArray;
  }

  public removeProductPrice(index: number) {
    this.productByPrices.removeAt(index);
  }

  public addProductPrice() {
    this.productByPrices.push(this.newproductByPrices());
  }
}
