import { error } from '@angular/compiler/src/util';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
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
    id: 0,
    name: 'All'
  };

  sortOptions = [
    {
      text: 'Name', value: 'name'
    },
    {
      text: 'Price Low to High', value: 'priceAsc'
    },
    {
      text: 'Price High to Low', value: 'priceDesc'
    }
  ];

  shopParams = new ShopParams();

  totalCount = 0;

  @ViewChild('txtSearch', { static: true }) txtSearch: ElementRef;

  constructor(private shopService: ShopService, searchElement: ElementRef) {
    this.txtSearch = searchElement;
  }

  ngOnInit(): void {
    this.loadBrands();
    this.loadTypes();
    this.loadProducts();

  }


  loadProducts() {
    this.shopService.getProducts(this.shopParams).subscribe(response => {
      complete: if (response != null) {
        this.products = response.data;
        this.totalCount = response.count;
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
      }
      else
        this.products = []
          ,
          alert

    });
  }

  loadBrands() {

    this.shopService.getBrands().subscribe(response => {
      complete: this.brands = [this.all, ...response],
        alert
    });
  }

  loadTypes() {
    this.shopService.getTypes().subscribe(response => {
      complete: this.productTypes = [this.all, ...response],
        alert
    });
  }

  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.loadProducts();
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.loadProducts();
  }

  onSortChanged($event: any) {
    this.shopParams.sort = $event.target.value;
    this.loadProducts();
  }

  onPageChanged($event: any) {
    if (this.shopParams.pageNumber != $event)
    {
      this.shopParams.pageNumber = $event;
      this.loadProducts();
    }
  }

  onSearchClicked() {
    this.shopParams.search = this.txtSearch.nativeElement.value;
    
    this.shopParams.pageNumber = 1;

    this.loadProducts();
  }

  onResetClicked(){
    this.shopParams = new ShopParams();
    this.txtSearch.nativeElement.value  = '';
    this.loadProducts();
  }

}
