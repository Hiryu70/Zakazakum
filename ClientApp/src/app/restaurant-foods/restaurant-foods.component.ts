import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm, GetFoodVm, UserVm } from '../api/api.client.generated';

@Component({
  selector: 'app-restaurant-foods',
  templateUrl: './restaurant-foods.component.html',
  styleUrls: []
})
export class RestaurantFoodsComponent implements OnInit {
  public users: UserVm[];
  public selectedUser: UserVm;
  public orders: GetOrdersVm[];
  public selectedOrder: GetOrdersVm;
  public foods: GetFoodVm[];

  constructor(private service: Service) { }

  ngOnInit() {
    this.refreshOrdersList();
    this.refreshUsersList();
  }

  orderChanged(){
    if (this.selectedOrder != undefined){
      this.refreshFoodsList();
    }
  }

  refreshFoodsList(){
    this.service.restaurant3(this.selectedOrder.restaurantId).subscribe(result => {
      this.foods = result.foods;
    });
  }

  refreshOrdersList(){
    this.service.order().subscribe(result => {
      this.orders = result.orders;
      this.orderChanged();
    });
  }

  refreshUsersList(){
    this.service.user().subscribe(result => {
      this.users = result.users;
    });
  }

}
