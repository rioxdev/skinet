import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products: IProduct[] = [];
  brands!: IBrand[];
  productTypes!: IType[];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.loadBrands();
    this.loadTypes();
    this.loadProducts();

  }


  loadProducts() {
    this.shopService.getProducts().subscribe(response => {
      complete: this.products = response.data,
        alert

    });
  }

  loadBrands() {
    this.shopService.getBrands().subscribe(response => {
      complete: this.brands = response,
        alert
    });
  }

  loadTypes() {
    this.shopService.getTypes().subscribe(response => {
      complete: this.productTypes = response,
        alert
    });
  }

}
