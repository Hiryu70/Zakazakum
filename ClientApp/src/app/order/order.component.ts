import { Component, OnInit } from '@angular/core';
import { Service, CreateOrderCommand, UserVm, RestaurantVm } from '../api/api.client.generated';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: []
})
export class OrderComponent implements OnInit {
  public users: UserVm[];
  public restaurants: RestaurantVm[];

  public order: CreateOrderCommand;
  registerForm: FormGroup;
  submitted = false;

  constructor(private service: Service, private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.refreshLists();
    this.order = new CreateOrderCommand();
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
        this.router.navigateByUrl('/order/' + res.orderId);
      },
      err => {
        console.log(err);
      }
    )
  }
}
