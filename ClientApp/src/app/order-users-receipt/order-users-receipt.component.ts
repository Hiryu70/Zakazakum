import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm, UserReceiptVm, DeliveryCostVm, UserPaidStatusVm } from '../api/api.client.generated';

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
  public totalCost: number;
  public ownerName: string;
  public ownerBank: string;
  public ownerPhoneNumber: string;

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
      this.ownerName = result.ownerName;
      this.ownerBank = result.ownerBank;
      this.ownerPhoneNumber = result.ownerPhoneNumber;
      this.totalCost = result.totalCost;
    });
  }

  onOrderPaidChanged(userId:string, event: any){
    if (this.selectedOrder != undefined){
      let userPaidStatusVm = new UserPaidStatusVm();
      userPaidStatusVm.isPaid = event.target.checked;
      userPaidStatusVm.userId = userId;

      this.service.setUserPaid(this.selectedOrder.id, userPaidStatusVm).subscribe(() => {
        this.refreshReceiptsList();
      });
    }
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
