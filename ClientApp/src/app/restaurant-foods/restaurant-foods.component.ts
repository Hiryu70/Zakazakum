import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm, GetFoodVm, UserVm, AddFoodOrderVm, DeleteFoodVm } from '../api/api.client.generated';
import { BsModalService } from 'ngx-bootstrap/modal';
import { AddFoodToOrderComponent } from '../add-food-to-order/add-food-to-order.component';
import { FoodComponent } from '../food/food.component';


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

  onCreateFood(){
    const initialState = {
      food: new GetFoodVm(),
      restaurantId: this.selectedOrder.restaurantId,
      restaurantFoodsComponent: this
    }
    this.modalService.show(FoodComponent, { initialState });
  }

  onAddFoodToOrder(food) {
    var foodOrder = new AddFoodOrderVm();
    foodOrder.userId = this.selectedUser.id;
    foodOrder.count = 1;
    foodOrder.foodId = food.id;

    const initialState = {
      foodTitle: food.title,
      foodOrder: foodOrder,
      orderId: this.selectedOrder.id
    }
    this.modalService.show(AddFoodToOrderComponent, { initialState });
  }

  onEditFood(food) {
    const initialState = {
      food: food,
      restaurantId: this.selectedOrder.restaurantId,
      restaurantFoodsComponent: this
    }
    this.modalService.show(FoodComponent, { initialState });
  }

  onDeleteFood(food: GetFoodVm){
    if (confirm('Удалить корм из кафехи?')) {
      let deleteFoodVm = new DeleteFoodVm();
      deleteFoodVm.id = food.id;
  
      this.service.food3(this.selectedOrder.restaurantId, deleteFoodVm).subscribe(
        res => {
          this.refreshFoodsList();
        },
        err => {
          console.log(err);
        });
    }
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
