import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm, UserReceiptVm, DeliveryCostVm } from '../api/api.client.generated';

@Component({
  selector: 'app-order-users-receipt',
  templateUrl: './order-users-receipt.component.html',
  styleUrls: []
})
export class OrderUsersReceiptComponent implements OnInit {
  public orders: GetOrdersVm[];
  public userReceipts: UserReceiptVm[];
  public selectedOrder: GetOrdersVm;
  public deliveryCost: number;

  constructor(private service: Service) { }


  ngOnInit() {
    this.refreshOrdersList();
  }

  orderChanged(){
    if (this.selectedOrder != undefined){
      this.refreshReceiptsList();
    }
  }

  refreshOrdersList(){
    this.service.order().subscribe(result => {
      this.orders = result.orders;
      this.orderChanged();
    });
  }

  refreshReceiptsList(){
    this.service.order3(this.selectedOrder.id).subscribe(result => {
      this.userReceipts = result.userReceipts;
      this.deliveryCost = result.deliveryCost;
    });
  }

  onDeliveryCostChanged(event: any) {
    if (this.selectedOrder != undefined){
      let deliveryCostVm = new DeliveryCostVm();
      if (event.target.value){
        deliveryCostVm.deliveryCost = event.target.value;
      } else {
        deliveryCostVm.deliveryCost = 0;
      }

      this.service.updateDeliveryCost(this.selectedOrder.id, deliveryCostVm).subscribe(() => {
        this.refreshReceiptsList();
      });
    }
  }

}
