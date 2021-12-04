import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ProductCategoryComponent} from "./product-category/product-category.component";

const routes: Routes = [
  {path:':id',component: ProductCategoryComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
