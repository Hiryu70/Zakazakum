import { Component, OnInit, EventEmitter, Input } from '@angular/core';
import { Service, GetFoodOrderVm, FoodGroupedReceiptVm, AddFoodOrderVm, DeleteFoodOrderVm, GetOrderVm } from '../api/api.client.generated';
import { BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { AddFoodToOrderComponent } from '../add-food-to-order/add-food-to-order.component';

@Component({
  selector: 'app-order-foods-receipt',
  templateUrl: './order-foods-receipt.component.html',
  styleUrls: []
})
export class OrderFoodsReceiptComponent implements OnInit {
  public order: GetOrderVm;
  @Input() orderLoadedEvent: EventEmitter<GetOrderVm>;
  @Input() orderChangedEvent: EventEmitter<void>;

  public foodOrders: GetFoodOrderVm[];
  public foodGroupedReceipts: FoodGroupedReceiptVm[];

  constructor(private service: Service, private modalService: BsModalService) { }

  ngOnInit() {
    this.orderLoadedEvent.subscribe(order => {
      this.order = order;
      this.foodOrders = order.foodReceipts;
      this.foodGroupedReceipts = order.foodGroupedReceipts;
     });
  }

  onEditFoodOrder(foodOrder: GetFoodOrderVm){
    var foodOrderVm = new AddFoodOrderVm();
    foodOrderVm.userId = foodOrder.userId;
    foodOrderVm.count = foodOrder.count;
    foodOrderVm.foodId = foodOrder.foodId;
    foodOrderVm.comment = foodOrder.comment;
    foodOrderVm.id = foodOrder.foodOrderId;

    const config: ModalOptions = {
      backdrop: 'static',
      keyboard: false,
      animated: true,
      ignoreBackdropClick: true,
      initialState: {
        orderFoodsReceiptComponent: this,
        foodTitle: foodOrder.title,
        foodOrder: foodOrderVm,
        orderId: this.order.id,
        orderChangedEvent: this.orderChangedEvent,
      }
    };

    this.modalService.show(AddFoodToOrderComponent, config);
  }

  onDeleteFoodOrder(foodOrder: GetFoodOrderVm){
    if (confirm('Действительно удалить из кормешки?')) {
      let deleteFoodOrderVm = new DeleteFoodOrderVm();
      deleteFoodOrderVm.id = foodOrder.foodOrderId;
      deleteFoodOrderVm.userId = foodOrder.userId;
  
      this.service.foodOrder3(this.order.id, deleteFoodOrderVm).subscribe(
        res => {
          this.orderChangedEvent.emit();
        },
        err => {
          console.log(err);
        });
    }
  }
}
