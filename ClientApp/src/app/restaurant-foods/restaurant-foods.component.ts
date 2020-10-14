import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { Service, GetFoodVm, UserVm, AddFoodOrderVm, DeleteFoodVm, GetOrderVm } from '../api/api.client.generated';
import { BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { AddFoodToOrderComponent } from '../add-food-to-order/add-food-to-order.component';
import { FoodComponent } from '../food/food.component';

@Component({
  selector: 'app-restaurant-foods',
  templateUrl: './restaurant-foods.component.html',
  styleUrls: ['./restaurant-foods.component.css']
})
export class RestaurantFoodsComponent implements OnInit {
  public hoveredElement:any;
  public order: GetOrderVm;
  @Input() orderLoadedEvent: EventEmitter<GetOrderVm>
  @Input() orderChangedEvent: EventEmitter<void>

  public users: UserVm[];
  public selectedUser: UserVm;
  public foods: GetFoodVm[];

  constructor(private service: Service, private modalService: BsModalService) { }


  ngOnInit() {
    this.orderLoadedEvent.subscribe(order => {
      this.order = order;
      this.refreshFoodsList();
      this.refreshUsersList();
     });
  }

  onCreateFood(){
    const config: ModalOptions = {
      backdrop: 'static',
      keyboard: false,
      animated: true,
      ignoreBackdropClick: true,
      initialState: {
        food: new GetFoodVm(),
        restaurantId: this.order.restaurantId,
        restaurantFoodsComponent: this
      }
    };
    this.modalService.show(FoodComponent, config);
  }

  onAddFoodToOrder(food) {
    var foodOrder = new AddFoodOrderVm();
    foodOrder.userId = this.selectedUser.id;
    foodOrder.count = 1;
    foodOrder.foodId = food.id;

    const config: ModalOptions = {
      backdrop: 'static',
      keyboard: false,
      animated: true,
      ignoreBackdropClick: true,
      initialState: {
        foodTitle: food.title,
        foodOrder: foodOrder,
        orderId: this.order.id,
        orderChangedEvent: this.orderChangedEvent
      }
    };
    this.modalService.show(AddFoodToOrderComponent, config);
  }

  onEditFood(food) {
    const config: ModalOptions = {
      backdrop: 'static',
      keyboard: false,
      animated: true,
      ignoreBackdropClick: true,
      initialState: {
        food: food,
        restaurantId: this.order.restaurantId,
        restaurantFoodsComponent: this
      }
    };
    this.modalService.show(FoodComponent, config);
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
    this.service.restaurant4(this.order.restaurantId).subscribe(result => {
      this.foods = result.foods;
    });
  }

  refreshUsersList() {
    this.service.user().subscribe(result => {
      let selectedUser = this.selectedUser;
      this.users = result.users;
      if (selectedUser != null){
        this.selectedUser = this.users.find(user  => user.id == selectedUser.id);
      }
    });
  }
  
  toggleHover(id) {
    this.hoveredElement = id
  }
  
  removeHover() {
    this.hoveredElement = null;
  }
}
