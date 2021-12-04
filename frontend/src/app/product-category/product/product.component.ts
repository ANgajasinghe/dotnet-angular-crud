import {Component, Input, OnInit} from '@angular/core';
import {Product} from "../../@core/interfaces/Product";
import {CartService} from "../../@core/services/cart.service";
import {Cart} from "../../@core/interfaces/Cart";

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input() product = {} as Product
  constructor(private cartService:CartService) { }

  ngOnInit(): void {
  }

  onProductClick(): void {
    this.cartService.sendItem(this.product);
  }




}
