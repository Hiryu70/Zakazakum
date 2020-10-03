import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm } from '../api/api.client.generated';
import { OrderStatusConverter } from '../services/order-status-converter';


@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: []
})
export class OrdersListComponent implements OnInit {
  public orders: GetOrdersVm[];

  constructor(private service: Service, public statusConverter: OrderStatusConverter) { }

  ngOnInit() {
    this.refreshList();
  }

  refreshList(){
    this.service.order(undefined).subscribe(result => {
      this.orders = result.orders;
    });
  }
}
