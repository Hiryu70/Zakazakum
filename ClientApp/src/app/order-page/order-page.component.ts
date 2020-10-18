import { Component, OnInit, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Service, GetOrderVm, OrderStatus, SetOrderStatusVm } from '../api/api.client.generated';
import { OrderStatusConverter } from '../services/order-status-converter';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.css']
})
export class OrderPageComponent implements OnInit {
  public id: number;
  public order: GetOrderVm = new GetOrderVm();
  public orderLoadedEvent: EventEmitter<GetOrderVm> = new EventEmitter<GetOrderVm>();
  public orderChangedEvent: EventEmitter<void> = new EventEmitter<void>();

  constructor(private route: ActivatedRoute, private router: Router, private service: Service, public statusConverter: OrderStatusConverter) { }

  ngOnInit() {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.service.order3(this.id).subscribe(result => {
      this.order = result;
      this.orderLoadedEvent.emit(result);
    },
    error => {
       console.log(error.message);
       this.router.navigate(['/404']);
  });

    this.orderChangedEvent.subscribe(() => {
      this.service.order3(this.id).subscribe(result => {
        this.order = result;
        this.orderLoadedEvent.emit(result);
      });
    });
  }


  closeOrder() {
    let orderStatus = new SetOrderStatusVm();
    orderStatus.orderStatus = OrderStatus._1;
    this.service.setOrderStatus(this.order.id, orderStatus).subscribe(result => {
      this.order.orderStatus = 1;
    })
  }

  openOrder() {
    let orderStatus = new SetOrderStatusVm();
    orderStatus.orderStatus = OrderStatus._0;
    this.service.setOrderStatus(this.order.id, orderStatus).subscribe(result => {
      this.order.orderStatus = 0;
    })
  }

  copyUrl() {
    var url = window.location.origin + this.router.url;
    console.log(url);  

    const selBox = document.createElement('textarea');
    selBox.style.position = 'fixed';
    selBox.style.left = '0';
    selBox.style.top = '0';
    selBox.style.opacity = '0';
    selBox.value = url;
    document.body.appendChild(selBox);
    selBox.focus();
    selBox.select();
    document.execCommand('copy');
    document.body.removeChild(selBox);
  }
}
