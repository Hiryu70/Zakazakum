import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm, GetFoodOrderVm, FoodGroupedReceiptVm, AddFoodOrderVm, DeleteFoodOrderVm } from '../api/api.client.generated';
import { BsModalService } from 'ngx-bootstrap/modal';
import { AddFoodToOrderComponent } from '../add-food-to-order/add-food-to-order.component';

@Component({
  selector: 'app-order-foods-receipt',
  templateUrl: './order-foods-receipt.component.html',
  styleUrls: []
})
export class OrderFoodsReceiptComponent implements OnInit {
  public orders: GetOrdersVm[];
  public foodOrders: GetFoodOrderVm[];
  public foodGroupedReceipts: FoodGroupedReceiptVm[];
  public selectedOrder: GetOrdersVm;

  constructor(private service: Service, private modalService: BsModalService) { }

  ngOnInit() {
    this.refreshOrdersList();
  }

  orderChanged(){
    if (this.selectedOrder != undefined){
      this.refreshFoodsList();
    }
  }

  refreshOrdersList(){
    this.service.order().subscribe(result => {
      this.orders = result.orders;
      this.orderChanged();
    });
  }

  public refreshFoodsList(){
    this.service.order3(this.selectedOrder.id).subscribe(result => {
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
      orderId: this.selectedOrder.id
    }
    this.modalService.show(AddFoodToOrderComponent, { initialState });
  }

  onDeleteFoodOrder(foodOrder: GetFoodOrderVm){
    if (confirm('Действительно удалить из кормешки?')) {
      let deleteFoodOrderVm = new DeleteFoodOrderVm();
      deleteFoodOrderVm.id = foodOrder.foodOrderId;
      deleteFoodOrderVm.userId = foodOrder.userId;
  
      this.service.foodOrder3(this.selectedOrder.id, deleteFoodOrderVm).subscribe(
        res => {
          this.refreshFoodsList();
        },
        err => {
          console.log(err);
        });
    }
  }
}
