import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule, routingComponents } from './app-routing.module';

import { Service, API_BASE_URL } from './api/api.client.generated';
import { OrderStatusConverter } from './services/order-status-converter';

import { AppComponent } from './app.component';
import { ModalModule } from 'ngx-bootstrap/modal';

import { MatCardModule} from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule ,LayoutGapStyleBuilder,StyleUtils,StylesheetMap,MediaMarshaller,ɵMatchMedia,
  BreakPointRegistry,PrintHook,LayoutStyleBuilder,FlexStyleBuilder,ShowHideStyleBuilder,FlexOrderStyleBuilder } from '@angular/flex-layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { RestaurantsListComponent } from './restaurants-list/restaurants-list.component';
import { UserComponent } from './user/user.component';
import { RestaurantFoodsComponent } from './restaurant-foods/restaurant-foods.component';
import { OrderFoodsReceiptComponent } from './order-foods-receipt/order-foods-receipt.component';
import { OrderUsersReceiptComponent } from './order-users-receipt/order-users-receipt.component';
import { AddFoodToOrderComponent } from './add-food-to-order/add-food-to-order.component';
import { FoodComponent } from './food/food.component';
import { OpenedOrdersListComponent } from './opened-orders-list/opened-orders-list.component';

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
    routingComponents,
    OpenedOrdersListComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FlexLayoutModule ,
    BrowserAnimationsModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    ModalModule.forRoot()
  ],
  entryComponents: [ 
    UserComponent,
    AddFoodToOrderComponent,
    FoodComponent
  ],
  providers: [
    StyleUtils,StylesheetMap,MediaMarshaller,ɵMatchMedia,BreakPointRegistry,PrintHook,LayoutStyleBuilder,
    FlexStyleBuilder,ShowHideStyleBuilder,FlexOrderStyleBuilder,LayoutGapStyleBuilder, 
    OrderStatusConverter,
    { provide: API_BASE_URL, useValue: "http://localhost:5000" },
    Service],
  bootstrap: [AppComponent]
})
export class AppModule { }
