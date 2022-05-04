import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product!: IProduct;

  constructor(private shopService : ShopService, private activeRoute : ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.activeRoute.snapshot.paramMap.get('id');
    if (id)
    this.loadProduct(parseInt(id));
  }

  private loadProduct(id: number)
  {
    this.shopService.getProduct(id).subscribe(reponse => {
      this.product = reponse;
    }, error => {
      console.log(error);
    });
    
  }

}
