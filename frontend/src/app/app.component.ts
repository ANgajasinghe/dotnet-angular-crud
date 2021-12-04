import {Component} from '@angular/core';
import {ProductCategoryService} from "./@core/services/product-category.service";
import {Router} from "@angular/router";
import {CartService} from "./@core/services/cart.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';

  productCategoryNames = [] as { id: number, name: string }[];

  constructor(private productCategoryService: ProductCategoryService, private cartService: CartService,private router: Router) {
    this.router.navigate(['/'])

    productCategoryService
      .init()
      .subscribe(data => {
        this.productCategoryNames = data;
        this.router.navigate([data[0].id])
      }, error => alert(error));

    cartService.init().subscribe();

  }


}
