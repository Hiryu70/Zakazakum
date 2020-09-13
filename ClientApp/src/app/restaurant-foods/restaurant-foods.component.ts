import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm, GetFoodVm } from '../api/api.client.generated';

@Component({
  selector: 'app-restaurant-foods',
  templateUrl: './restaurant-foods.component.html',
  styleUrls: []
})
export class RestaurantFoodsComponent implements OnInit {
  public orders: GetOrdersVm[];
  public foods: GetFoodVm[];
  public selectedOrder: GetOrdersVm;
  
  constructor(private service: Service) { }

  ngOnInit() {
    this.refreshOrdersList();
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

}
