import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm,  OrderStatus } from '../api/api.client.generated';

@Component({
  selector: 'app-opened-orders-list',
  templateUrl: './opened-orders-list.component.html',
  styleUrls: []
})
export class OpenedOrdersListComponent implements OnInit {
  public orders: GetOrdersVm[];

  constructor(private service: Service) { }

  ngOnInit() {
    this.refreshList();
  }

  refreshList(){
    this.service.order(OrderStatus._0).subscribe(result => {
      this.orders = result.orders;
    });
  }


}
