import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsListComponent } from './pages/list/products-list.component';
import { ProductsCreateComponent } from './pages/create/products-create.component';
import { ProductsDetailComponent } from './pages/detail/products-detail.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'list',
        component: ProductsListComponent,
      },
      {
        path: 'create',
        component: ProductsCreateComponent,
      },
      {
        path: 'update/:id',
        component: ProductsCreateComponent,
      },
      {
        path: 'detail/:id',
        component: ProductsDetailComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
