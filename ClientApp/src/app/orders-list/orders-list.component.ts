import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm } from '../api/api.client.generated';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: []
})
export class OrdersListComponent implements OnInit {
  public orders: GetOrdersVm[];

  constructor(private service: Service) { }

  ngOnInit() {
    this.refreshList();
  }

  refreshList(){
    this.service.order().subscribe(result => {
      this.orders = result.orders;
    });
  }

}
