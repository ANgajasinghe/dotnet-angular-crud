import {Component, OnDestroy, OnInit} from '@angular/core';
import {Cart} from "../@core/interfaces/Cart";
import {CartService} from "../@core/services/cart.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit , OnDestroy{

  subscription = new Subscription();
  cartItems = [] as Cart[];
  constructor(private cartService: CartService) { }

  ngOnInit(): void {
   this.subscription = this.cartService.getCartItems().subscribe(cart => {
      this.cartItems = cart;
    });
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  onUpdateCart(index: number, cart: Cart, target: any) {
    this.cartService.updateCart(index,cart, +target.value);

  }

  onProductDelete(index: number): void {
    this.cartService.deleteCartItem(index);
  }

  onSaveCart() {
    this.cartService.saveCar().subscribe(res=> alert('cart saved successfully'),error => alert('error'));
  }
}
