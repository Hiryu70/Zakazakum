import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { RestaurantFoodsComponent } from './restaurant-foods/restaurant-foods.component';
import { UsersListComponent } from './users-list/users-list.component';
import { OrderPageComponent } from './order-page/order-page.component';

const routes: Routes = [
  { path: 'orders', component: OrdersListComponent},
  { path: 'users', component: UsersListComponent},
  { path: '', component: OrdersListComponent},
  { path: 'order/:id', component: OrderPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
export const routingComponents = [OrdersListComponent, UsersListComponent, RestaurantFoodsComponent, OrderPageComponent]