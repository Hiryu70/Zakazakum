import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrderComponent } from './order/order.component';
import { UsersListComponent } from './users-list/users-list.component';
import { OrderPageComponent } from './order-page/order-page.component';
import { RestaurantsListComponent } from './restaurants-list/restaurants-list.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  { path: 'orders', component: OrdersListComponent},
  { path: 'users', component: UsersListComponent},
  { path: 'restaurants', component: RestaurantsListComponent},
  { path: '', component: OrderComponent},
  { path: 'order/:id', component: OrderPageComponent},
  { path: '404', component: NotFoundComponent},
  { path: '**', redirectTo: '/404'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
export const routingComponents = [OrdersListComponent, UsersListComponent, OrderComponent, OrderPageComponent, RestaurantsListComponent, NotFoundComponent]