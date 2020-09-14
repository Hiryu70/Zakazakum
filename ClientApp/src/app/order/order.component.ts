import { Component, OnInit } from '@angular/core';
import { Service, CreateOrderCommand, UserVm, RestaurantVm } from '../api/api.client.generated';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OrdersListComponent } from '../orders-list/orders-list.component';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: []
})
export class OrderComponent implements OnInit {
  public users: UserVm[];
  public restaurants: RestaurantVm[];

  public order: CreateOrderCommand;
  public ordersListComponent: OrdersListComponent;
  registerForm: FormGroup;
  submitted = false;

  constructor(private bsModalRef: BsModalRef, private service: Service, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.refreshLists();
    this.registerForm = this.formBuilder.group({
      ownerId: ['', [Validators.required]],
      restaurantId: ['', [Validators.required]]
    });
  }

  get f() { return this.registerForm.controls; }

  refreshLists(){
    this.service.user().subscribe(result => {
      this.users = result.users;
    });
    this.service.restaurant().subscribe(result => {
      this.restaurants = result.restaurants;
    });
  }

  chageOwner(e) {
    this.ownerId.setValue(e.target.value.toString().split(' ')[1], {
      onlySelf: true
    })
  }

  get ownerId() {
    return this.registerForm.get('ownerId');
  }

  chageRestaurant(e) {
    this.restaurantId.setValue(e.target.value.toString().split(' ')[1], {
      onlySelf: true
    })
  }

  get restaurantId() {
    return this.registerForm.get('restaurantId');
  }

  public onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    this.order.ownerId = this.registerForm.controls['ownerId'].value;
    this.order.restaurantId = this.registerForm.controls['restaurantId'].value;

    this.service.order2(this.order).subscribe(
      res => {
        this.ordersListComponent.refreshList();
        this.bsModalRef.hide();
      },
      err => {
        console.log(err);
      }
    )
  }

  public closeModal() {
    this.bsModalRef.hide();
  }
}
