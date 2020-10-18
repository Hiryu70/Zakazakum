import { environment } from './../environments/environment';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule, routingComponents } from './app-routing.module';

import { Service, API_BASE_URL } from './api/api.client.generated';
import { OrderStatusConverter } from './services/order-status-converter';

import { AppComponent } from './app.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MatCardModule} from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { UserComponent } from './user/user.component';
import { RestaurantFoodsComponent } from './restaurant-foods/restaurant-foods.component';
import { OrderFoodsReceiptComponent } from './order-foods-receipt/order-foods-receipt.component';
import { OrderUsersReceiptComponent } from './order-users-receipt/order-users-receipt.component';
import { AddFoodToOrderComponent } from './add-food-to-order/add-food-to-order.component';
import { FoodComponent } from './food/food.component';
import { OpenedOrdersListComponent } from './opened-orders-list/opened-orders-list.component';
import { OrderFoodsGroupedReceiptComponent } from './order-foods-grouped-receipt/order-foods-grouped-receipt.component';
import { RestaurantComponent } from './restaurant/restaurant.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    OrderFoodsReceiptComponent,
    OrderUsersReceiptComponent,
    AddFoodToOrderComponent,
    FoodComponent,
    RestaurantFoodsComponent,
    OpenedOrdersListComponent,
    OrderFoodsGroupedReceiptComponent,
    RestaurantComponent,
    routingComponents,
  ],
  imports: [
    FlexLayoutModule,
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    ModalModule.forRoot()
  ],
  entryComponents: [ 
    UserComponent,
    RestaurantComponent,
    AddFoodToOrderComponent,
    FoodComponent
  ],
  providers: [
    OrderStatusConverter,
    { provide: API_BASE_URL, useValue: environment.apiUrl },
    Service],
  bootstrap: [AppComponent]
})
export class AppModule { }
