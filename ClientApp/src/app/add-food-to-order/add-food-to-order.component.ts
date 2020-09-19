import { Component, OnInit } from '@angular/core';
import { Service, FoodOrderVm, } from '../api/api.client.generated';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';


@Component({
  selector: 'app-add-food-to-order',
  templateUrl: './add-food-to-order.component.html',
  styleUrls: []
})
export class AddFoodToOrderComponent implements OnInit {
  public foodOrder: FoodOrderVm;
  public foodTitle: string;
  public orderId: number;
  registerForm: FormGroup;
  submitted = false;

  constructor(private bsModalRef: BsModalRef, private service: Service, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      count: [this.foodOrder.count, [Validators.required]],
      comment: [this.foodOrder.comment]
    });
  }

  get f() { return this.registerForm.controls; }

  public onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    if (this.foodOrder.id === undefined) {
      this.foodOrder.count = this.registerForm.controls['count'].value;
      this.foodOrder.comment = this.registerForm.controls['comment'].value;

      this.service.addFoodOrder(this.orderId, this.foodOrder).subscribe(
        res => {
          this.bsModalRef.hide();
        },
        err => {
          console.log(err);
        });
    }
  }

  public closeModal() {
    this.bsModalRef.hide();
  }

}
