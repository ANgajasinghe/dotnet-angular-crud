import {Injectable} from '@angular/core';
import {Observable, Subject} from "rxjs";
import {Cart} from "../interfaces/Cart";
import {Product} from "../interfaces/Product";
import {HttpClient} from "@angular/common/http";
import {ProductCategory} from "../interfaces/ProductCategory";
import {map, tap} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartItems = [] as Cart[];

  constructor(private http: HttpClient) {
  }

  private subject = new Subject<Cart[]>();

  public init(): Observable<Cart[]> {
    return this.http.get<Cart[]>('https://localhost:7087/api/Cart')
      .pipe(
       tap(x=> {
         this.cartItems = x;
         this.subject.next(this.cartItems);
       })
      )
  }




  sendItem(product: Product) {

    if (this.cartItems.length == 0) {
      this.addCartItem(product);
    } else {
      if (this.cartItems.some(x => x.product.id == product.id)) {
        this.cartItems.forEach(x => {
          if (x.productId == product.id) {
            x.quantity += 1;
            x.price = product.unitPrice * x.quantity;
            return;
          }
        })
      } else {
        this.addCartItem(product);
      }

    }

    this.subject.next(this.cartItems);
  }


  getCartItems(): Observable<any> {
    return this.subject.asObservable();
  }


  updateCart(index: number, cart: Cart, updatedQty: number) {
    cart.quantity = updatedQty;
    cart.price = updatedQty * cart.product.unitPrice;
    this.cartItems[index] = cart;
    this.subject.next(this.cartItems);

  }

  deleteCartItem(index: number) {
    this.cartItems.splice(index, 1);
    this.subject.next(this.cartItems);

  }

  saveCar(): Observable<Cart[]> {
    console.log(this.cartItems);
   return this.http.post<Cart[]>('https://localhost:7087/api/Cart/all', this.cartItems)
  }

  private addCartItem(product: Product): void {
    const cartItem = {
      productId: product.id,
      quantity: 1,
      price: product.unitPrice,
      product: product
    } as Cart;
    this.cartItems.push(cartItem)
  }





}
