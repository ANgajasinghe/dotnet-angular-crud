import {Product} from "./Product";

export interface ProductCategory {
  id: number;
  name: string;
  products: Product[];
}
