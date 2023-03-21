export interface Product {
  id?:string
  name: string;
  marca: string;
  productByPrices: Array<ProductPrice>;
}

export interface ProductPrice {
  id?: string;
  productId: string;
  color: string;
  cost: number;
  // product: Product;
}
