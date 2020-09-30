import { Component, OnInit, EventEmitter, Input } from '@angular/core';
import { Service, GetOrdersVm, GetFoodOrderVm, FoodGroupedReceiptVm, AddFoodOrderVm, DeleteFoodOrderVm, GetOrderVm } from '../api/api.client.generated';
import { BsModalService } from 'ngx-bootstrap/modal';
import { AddFoodToOrderComponent } from '../add-food-to-order/add-food-to-order.component';

@Component({
  selector: 'app-order-foods-receipt',
  templateUrl: './order-foods-receipt.component.html',
  styleUrls: []
})
export class OrderFoodsReceiptComponent implements OnInit {
  public order: GetOrderVm;
  @Input() getOrderEvent: EventEmitter<GetOrderVm>

  public foodOrders: GetFoodOrderVm[];
  public foodGroupedReceipts: FoodGroupedReceiptVm[];

  constructor(private service: Service, private modalService: BsModalService) { }

  ngOnInit() {
    this.getOrderEvent.subscribe(order => {
      this.order = order;
      this.refreshFoodsList();
     });
  }


  public refreshFoodsList(){
    this.service.order3(this.order.id).subscribe(result => {
      this.foodOrders = result.foodReceipts;
      this.foodGroupedReceipts = result.foodGroupedReceipts;
    });
  }

  onEditFoodOrder(foodOrder: GetFoodOrderVm){
    var foodOrderVm = new AddFoodOrderVm();
    foodOrderVm.userId = foodOrder.userId;
    foodOrderVm.count = foodOrder.count;
    foodOrderVm.foodId = foodOrder.foodId;
    foodOrderVm.comment = foodOrder.comment;
    foodOrderVm.id = foodOrder.foodOrderId;

    const initialState = {
      orderFoodsReceiptComponent: this,
      foodTitle: foodOrder.title,
      foodOrder: foodOrderVm,
      orderId: this.order.id
    }
    this.modalService.show(AddFoodToOrderComponent, { initialState });
  }

  onDeleteFoodOrder(foodOrder: GetFoodOrderVm){
    if (confirm('Действительно удалить из кормешки?')) {
      let deleteFoodOrderVm = new DeleteFoodOrderVm();
      deleteFoodOrderVm.id = foodOrder.foodOrderId;
      deleteFoodOrderVm.userId = foodOrder.userId;
  
      this.service.foodOrder3(this.order.id, deleteFoodOrderVm).subscribe(
        res => {
          this.refreshFoodsList();
        },
        err => {
          console.log(err);
        });
    }
  }
}
