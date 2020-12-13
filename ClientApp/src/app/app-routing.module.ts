import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrderComponent } from './order/order.component';
import { UsersListComponent } from './users-list/users-list.component';
import { OrderPageComponent } from './order-page/order-page.component';
import { RestaurantsListComponent } from './restaurants-list/restaurants-list.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: 'registration', component: RegistrationComponent},
  { path: 'login', component: LoginComponent},
  { path: 'orders', component: OrdersListComponent, canActivate:[AuthGuard]},
  { path: 'users', component: UsersListComponent, canActivate:[AuthGuard]},
  { path: 'restaurants', component: RestaurantsListComponent, canActivate:[AuthGuard]},
  { path: '', component: OrderComponent, canActivate:[AuthGuard]},
  { path: 'order/:id', component: OrderPageComponent, canActivate:[AuthGuard]},
  { path: '404', component: NotFoundComponent, canActivate:[AuthGuard]},
  { path: '**', redirectTo: '/404'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
export const routingComponents = [OrdersListComponent, 
  UsersListComponent,
   OrderComponent, 
   OrderPageComponent, 
   RestaurantsListComponent, 
   NotFoundComponent, 
   LoginComponent, 
   RegistrationComponent]