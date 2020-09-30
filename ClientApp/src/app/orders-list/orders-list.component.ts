import { Component, OnInit } from '@angular/core';
import { Service, GetOrdersVm } from '../api/api.client.generated';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: []
})
export class OrdersListComponent implements OnInit {
  public statuses: { [id: string] : string; } = {};
  public orders: GetOrdersVm[];

  constructor(private service: Service) { }

  ngOnInit() {
    this.fillStatuses();
    this.refreshList();
  }

  fillStatuses(){
    this.statuses["Open"] = "Открыт";
    this.statuses["Closed"] = "Прием закрыт";
    this.statuses["Delivered"] = "Доставлен";
    this.statuses["Finished"] = "Все оплатили";
    this.statuses["Cancelled"] = "Отменен";
  }

  refreshList(){
    this.service.order(undefined).subscribe(result => {
      this.orders = result.orders;
    });
  }
}
