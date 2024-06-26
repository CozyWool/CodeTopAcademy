import { Component, OnInit } from '@angular/core';
import { DataService, ProductModel } from '../data.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
})
export class ProductsComponent implements OnInit {
  isLoaded: boolean = false;
  products: ProductModel[] = [];

  constructor(private dataService: DataService){

  }

  ngOnInit(): void {
    console.log('ProductsComponent');
    this.dataService
        .getProducts()
        .subscribe((data: ProductModel[])=> {
          this.isLoaded = true;
          this.products=data;
        });
  }

}
