import { Component, OnInit, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Service, GetOrderVm } from '../api/api.client.generated';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: []
})
export class OrderPageComponent implements OnInit {
  public order: GetOrderVm = new GetOrderVm();
  public getOrderEvent: EventEmitter<GetOrderVm> = new EventEmitter<GetOrderVm>();
  public id : number;
  constructor(private route: ActivatedRoute, private service: Service) { }

  ngOnInit() {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.service.order3(this.id).subscribe(result => {
      this.order = result;
      this.getOrderEvent.emit(result);
    });
  }

}
