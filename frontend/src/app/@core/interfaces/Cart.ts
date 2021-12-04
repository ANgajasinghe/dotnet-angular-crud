import {Product} from "./Product";

export interface Cart{
  id: number;
  productId: number;
  product: Product;
  quantity: number;
  price: number;
}
