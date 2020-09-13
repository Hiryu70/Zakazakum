import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm, FoodReceiptVm } from '../api/api.client.generated';


@Component({
  selector: 'app-order-foods-receipt',
  templateUrl: './order-foods-receipt.component.html',
  styleUrls: []
})
export class OrderFoodsReceiptComponent implements OnInit {
  public orders: GetOrdersVm[];
  public foodReceipts: FoodReceiptVm[];
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

  refreshOrdersList(){
    this.service.order().subscribe(result => {
      this.orders = result.orders;
      this.orderChanged();
    });
  }

  refreshFoodsList(){
    this.service.order3(this.selectedOrder.id).subscribe(result => {
      this.foodReceipts = result.foodReceipts;
    });
  }
}
