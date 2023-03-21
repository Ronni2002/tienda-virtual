import { SharedModule } from './../../shared/shared.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductsDetailComponent } from './pages/detail/products-detail.component';
import { ProductsCreateComponent } from './pages/create/products-create.component';
import { ProductsListComponent } from './pages/list/products-list.component';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDividerModule } from 'ng-zorro-antd/divider';
@NgModule({
  declarations: [
    ProductsDetailComponent,
    ProductsCreateComponent,
    ProductsListComponent
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    NzTableModule,
    NzDividerModule,
    RouterModule,
    SharedModule
  ]
})
export class ProductsModule { }
