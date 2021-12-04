import { Component, OnInit } from '@angular/core';
import {ProductCategoryService} from "../@core/services/product-category.service";
import {ActivatedRoute} from "@angular/router";
import {Product} from "../@core/interfaces/Product";

@Component({
  selector: 'app-product-category',
  templateUrl: './product-category.component.html',
  styleUrls: ['./product-category.component.css']
})
export class ProductCategoryComponent implements OnInit {

  products = [] as Product[]
  constructor(public productCategoryService: ProductCategoryService, private activateRouter: ActivatedRoute) { }

  ngOnInit(): void {
    this.activateRouter.params.subscribe(param=>{
      this.products = this.productCategoryService.getProductsByCategoryId(+param.id)
    });


  }

}
