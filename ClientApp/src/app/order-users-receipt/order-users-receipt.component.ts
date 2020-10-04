import { Component, OnInit, EventEmitter, Input } from '@angular/core';
import { Service, UserReceiptVm, DeliveryCostVm, UserPaidStatusVm, GetOrderVm } from '../api/api.client.generated';

@Component({
  selector: 'app-order-users-receipt',
  templateUrl: './order-users-receipt.component.html',
  styleUrls: []
})
export class OrderUsersReceiptComponent implements OnInit {
  public order: GetOrderVm;
  @Input() orderLoadedEvent: EventEmitter<GetOrderVm>

  public userReceipts: UserReceiptVm[];
  public deliveryCost: number;
  public totalCost: number;
  public ownerName: string;
  public ownerBank: string;
  public ownerPhoneNumber: string;

  constructor(private service: Service) { }

  ngOnInit() {
    this.orderLoadedEvent.subscribe(order => {
      this.order = order;
      this.refreshReceiptsList();
     });
  }

  refreshReceiptsList(){
    this.service.order3(this.order.id).subscribe(result => {
      this.userReceipts = result.userReceipts;
      this.deliveryCost = result.deliveryCost;
      this.ownerName = result.ownerName;
      this.ownerBank = result.ownerBank;
      this.ownerPhoneNumber = result.ownerPhoneNumber;
      this.totalCost = result.totalCost;
    });
  }

  onOrderPaidChanged(userId:string, event: any){
    if (this.order != undefined){
      let userPaidStatusVm = new UserPaidStatusVm();
      userPaidStatusVm.isPaid = event.target.checked;
      userPaidStatusVm.userId = userId;

      this.service.setUserPaid(this.order.id, userPaidStatusVm).subscribe(() => {
        this.refreshReceiptsList();
      });
    }
  }

  onDeliveryCostChanged(event: any) {
    if (this.order != undefined){
      let deliveryCostVm = new DeliveryCostVm();
      if (event.target.value){
        deliveryCostVm.deliveryCost = event.target.value;
      } else {
        deliveryCostVm.deliveryCost = 0;
      }

      this.service.updateDeliveryCost(this.order.id, deliveryCostVm).subscribe(() => {
        this.refreshReceiptsList();
      });
    }
  }

}
