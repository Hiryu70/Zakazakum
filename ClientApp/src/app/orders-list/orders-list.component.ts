import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Service, GetOrdersVm, CreateOrderCommand } from '../api/api.client.generated';
import { OrderComponent } from '../order/order.component';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: []
})
export class OrdersListComponent implements OnInit {
  public orders: GetOrdersVm[];

  constructor(private service: Service, private modalService: BsModalService) { }

  ngOnInit() {
    this.refreshList();
  }

  refreshList(){
    this.service.order().subscribe(result => {
      this.orders = result.orders;
    });
  }

  newOrder(){
    const initialState = {
      order: new CreateOrderCommand(),
      ordersListComponent: this
    };
    this.modalService.show(OrderComponent, { initialState });
  }

}
