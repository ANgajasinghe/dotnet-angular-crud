import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ProductCategory} from "../interfaces/ProductCategory";
import {Observable} from "rxjs";
import {map, tap} from "rxjs/operators";
import {Product} from "../interfaces/Product";

@Injectable({
  providedIn: 'root'
})
export class ProductCategoryService {

  productNames = [] as string[];
  productCategories = [] as ProductCategory[];

  constructor(private http: HttpClient) {
  }

  public init(): Observable<{ id: number, name: string }[]> {
    return this.http.get<ProductCategory[]>('https://localhost:7087/api/ProductCategory')
      .pipe(
        map(productCategories => {
          this.productCategories = productCategories;
          return productCategories.map(x => {
            return {id: x.id, name: x.name};
          });
        })
      )
  }

  public getProductsByCategoryId(id: number): Product[] {
   return  this.productCategories?.filter(x => x.id == id)[0]?.products;
  }

}

