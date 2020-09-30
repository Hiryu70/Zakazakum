import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule, routingComponents } from './app-routing.module';

import { Service, API_BASE_URL } from './api/api.client.generated';

import { AppComponent } from './app.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { RestaurantsListComponent } from './restaurants-list/restaurants-list.component';
import { UserComponent } from './user/user.component';


import { RestaurantFoodsComponent } from './restaurant-foods/restaurant-foods.component';
import { OrderFoodsReceiptComponent } from './order-foods-receipt/order-foods-receipt.component';
import { OrderUsersReceiptComponent } from './order-users-receipt/order-users-receipt.component';
import { AddFoodToOrderComponent } from './add-food-to-order/add-food-to-order.component';
import { FoodComponent } from './food/food.component';

@NgModule({
  declarations: [
    AppComponent,
    RestaurantsListComponent,
    UserComponent,
    OrderFoodsReceiptComponent,
    OrderUsersReceiptComponent,
    AddFoodToOrderComponent,
    FoodComponent,
    RestaurantFoodsComponent,
    routingComponents
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ModalModule.forRoot()
  ],
  entryComponents: [ 
    UserComponent,
    AddFoodToOrderComponent,
    FoodComponent
  ],
  providers: [
    { provide: API_BASE_URL, useValue: "http://localhost:5000" },
    Service],
  bootstrap: [AppComponent]
})
export class AppModule { }
