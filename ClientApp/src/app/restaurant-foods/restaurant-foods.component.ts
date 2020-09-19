import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm, GetFoodVm, UserVm, FoodOrderVm, } from '../api/api.client.generated';
import { BsModalService } from 'ngx-bootstrap/modal';
import { AddFoodToOrderComponent } from '../add-food-to-order/add-food-to-order.component';


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

  constructor(private service: Service, private modalService: BsModalService) { }

  ngOnInit() {
    this.refreshOrdersList();
    this.refreshUsersList();
  }

  onAddFoodToOrder(foodId, foodTitle) {
    var foodOrder = new FoodOrderVm();
    foodOrder.userId = this.selectedUser.id;
    foodOrder.count = 1;
    foodOrder.foodId = foodId;

    const initialState = {
      foodTitle: foodTitle,
      foodOrder: foodOrder,
      orderId: this.selectedOrder.id
    }
    this.modalService.show(AddFoodToOrderComponent, { initialState });
  }

  orderChanged() {
    if (this.selectedOrder != undefined) {
      this.refreshFoodsList();
    }
  }

  refreshFoodsList() {
    this.service.restaurant3(this.selectedOrder.restaurantId).subscribe(result => {
      this.foods = result.foods;
    });
  }

  refreshOrdersList() {
    this.service.order().subscribe(result => {
      this.orders = result.orders;
      this.orderChanged();
    });
  }

  refreshUsersList() {
    this.service.user().subscribe(result => {
      this.users = result.users;
    });
  }

}
