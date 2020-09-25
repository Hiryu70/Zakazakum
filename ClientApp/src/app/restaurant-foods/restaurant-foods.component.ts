import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { Service, GetFoodVm, UserVm, AddFoodOrderVm, DeleteFoodVm, GetOrderVm } from '../api/api.client.generated';
import { BsModalService } from 'ngx-bootstrap/modal';
import { AddFoodToOrderComponent } from '../add-food-to-order/add-food-to-order.component';
import { FoodComponent } from '../food/food.component';

@Component({
  selector: 'app-restaurant-foods',
  templateUrl: './restaurant-foods.component.html',
  styleUrls: []
})
export class RestaurantFoodsComponent implements OnInit {

  public order: GetOrderVm;
  @Input() getOrderEvent: EventEmitter<GetOrderVm>


  public users: UserVm[];
  public selectedUser: UserVm;
  public foods: GetFoodVm[];

  constructor(private service: Service, private modalService: BsModalService) { }


  ngOnInit() {
    this.getOrderEvent.subscribe(order => {
      this.order = order;
      this.refreshFoodsList();
      this.refreshUsersList();
     });
  }

  onCreateFood(){
    const initialState = {
      food: new GetFoodVm(),
      restaurantId: this.order.restaurantId,
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
      orderId: this.order.id
    }
    this.modalService.show(AddFoodToOrderComponent, { initialState });
  }

  onEditFood(food) {
    const initialState = {
      food: food,
      restaurantId: this.order.restaurantId,
      restaurantFoodsComponent: this
    }
    this.modalService.show(FoodComponent, { initialState });
  }

  onDeleteFood(food: GetFoodVm){
    if (confirm('Удалить корм из кафехи?')) {
      let deleteFoodVm = new DeleteFoodVm();
      deleteFoodVm.id = food.id;
  
      this.service.food3(this.order.restaurantId, deleteFoodVm).subscribe(
        res => {
          this.refreshFoodsList();
        },
        err => {
          console.log(err);
        });
    }
  }


  refreshFoodsList() {
    this.service.restaurant3(this.order.restaurantId).subscribe(result => {
      this.foods = result.foods;
    });
  }

  refreshUsersList() {
    this.service.user().subscribe(result => {
      this.users = result.users;
    });
  }
}
