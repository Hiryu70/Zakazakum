import { Component, OnInit, EventEmitter } from '@angular/core';
import { Service, AddFoodOrderVm, UpdateFoodOrderVm } from '../api/api.client.generated';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { OrderFoodsReceiptComponent } from '../order-foods-receipt/order-foods-receipt.component';


@Component({
  selector: 'app-add-food-to-order',
  templateUrl: './add-food-to-order.component.html',
  styleUrls: []
})
export class AddFoodToOrderComponent implements OnInit {
  public orderFoodsReceiptComponent: OrderFoodsReceiptComponent;
  public foodOrder: AddFoodOrderVm;
  public foodTitle: string;
  public orderId: number;
  public orderChangedEvent: EventEmitter<void>;
  
  registerForm: FormGroup;
  submitted = false;

  constructor(private bsModalRef: BsModalRef, private service: Service, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      count: [this.foodOrder.count, [Validators.required, Validators.min(1)]],
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

      this.service.foodOrder(this.orderId, this.foodOrder).subscribe(
        res => {
          this.orderChangedEvent.emit();
          this.bsModalRef.hide();
        },
        err => {
          console.log(err);
        });
    }
    else{
      let updateFoodOrder = new UpdateFoodOrderVm();
      updateFoodOrder.count = this.registerForm.controls['count'].value;
      updateFoodOrder.comment = this.registerForm.controls['comment'].value;
      updateFoodOrder.id = this.foodOrder.id;
      updateFoodOrder.userId = this.foodOrder.userId;
      updateFoodOrder.foodId = this.foodOrder.foodId;

      this.service.foodOrder2(this.orderId, updateFoodOrder).subscribe(
        res => {
          this.orderChangedEvent.emit();
          this.bsModalRef.hide();
          // this.orderFoodsReceiptComponent.refreshFoodsList();
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
