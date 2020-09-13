import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';

import { Service, API_BASE_URL } from './api/api.client.generated';

import { AppComponent } from './app.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { RestaurantsListComponent } from './restaurants-list/restaurants-list.component';
import { UserComponent } from './user/user.component';
import { UsersListComponent } from './users-list/users-list.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { RestaurantFoodsComponent } from './restaurant-foods/restaurant-foods.component';
import { OrderFoodsComponent } from './order-foods/order-foods.component';

@NgModule({
  declarations: [
    AppComponent,
    RestaurantsListComponent,
    UserComponent,
    UsersListComponent,
    OrdersListComponent,
    RestaurantFoodsComponent,
    OrderFoodsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ModalModule.forRoot()
  ],
  entryComponents: [ 
    UserComponent
  ],
  providers: [
    { provide: API_BASE_URL, useValue: "http://localhost:5000" },
    Service],
  bootstrap: [AppComponent]
})
export class AppModule { }
