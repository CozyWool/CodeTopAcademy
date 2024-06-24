import { Component, OnInit } from '@angular/core';
import { DataService, ProductModel } from '../data.service';

@Component({
  selector: 'app-products',
  template: './products.component.html',
  // styles: 'products.component.css'
})
export class ProductsComponent implements OnInit {
  isLoaded: boolean = false;
  products: ProductModel[] = [];
  constructor(private dataService: DataService) {

  }
  ngOnInit(): void {
    this.dataService
      .getProducts()
      .subscribe((data: ProductModel[]) => {
        this.isLoaded = true;
        this.products = data;
      });
  }

}
