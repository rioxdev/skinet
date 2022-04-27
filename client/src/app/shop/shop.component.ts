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

  all = {
    id : 0,
    name : 'All'
  };

  selectedBrans = 0;
  selectedType = 0;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.loadBrands();
    this.loadTypes();
    this.loadProducts();

  }


  loadProducts() {
    this.shopService.getProducts(this.selectedBrans, this.selectedType).subscribe(response => {
      complete: if (response != null) this.products = response.data; 
              else
              this.products = []
        ,
        alert

    });
  }

  loadBrands() {
   
    this.shopService.getBrands().subscribe(response => {
      complete: this.brands = [this.all, ...response] ,
        alert
    });
  }

  loadTypes() {
    this.shopService.getTypes().subscribe(response => {
      complete: this.productTypes = [this.all, ...response],
        alert
    });
  }

  onBrandSelected(brandId : number)
  {
    console.log(brandId);
      this.selectedBrans = brandId;
      this.loadProducts();
  }

  onTypeSelected(typeId : number)
  {
    console.log(typeId);
      this.selectedType = typeId;
      this.loadProducts();
  }

}
