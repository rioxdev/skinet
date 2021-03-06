import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ProductItemComponent } from './shop/product-item/product-item.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'test-error', component: TestErrorComponent},
  { path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule) },
  { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule) },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
