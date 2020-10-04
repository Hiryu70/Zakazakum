import { Component, OnInit, EventEmitter, Input } from '@angular/core';
import { FoodGroupedReceiptVm, GetOrderVm } from '../api/api.client.generated';

@Component({
  selector: 'app-order-foods-grouped-receipt',
  templateUrl: './order-foods-grouped-receipt.component.html',
  styleUrls: []
})
export class OrderFoodsGroupedReceiptComponent implements OnInit {
  @Input() orderLoadedEvent: EventEmitter<GetOrderVm>

  public foodGroupedReceipts: FoodGroupedReceiptVm[];

  constructor() { }

  ngOnInit() {
    this.orderLoadedEvent.subscribe(order => {
      this.foodGroupedReceipts = order.foodGroupedReceipts;
     });
  }
}
