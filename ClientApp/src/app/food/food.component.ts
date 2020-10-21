import { Component, OnInit } from '@angular/core';
import { Service, GetFoodVm, AddFoodVm, EditFoodVm } from '../api/api.client.generated';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RestaurantFoodsComponent } from '../restaurant-foods/restaurant-foods.component';
import { IsFoodTitleTaken } from '../validators/is-food-title-taken.validator';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: []
})
export class FoodComponent implements OnInit {
  public restaurantId: string;
  public food: GetFoodVm;
  public restaurantFoodsComponent: RestaurantFoodsComponent;
  registerForm: FormGroup;
  submitted = false;

  constructor(private bsModalRef: BsModalRef, private service: Service, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      title: [this.food.title, [Validators.required]],
      description: [this.food.description],
      cost: [this.food.cost, [Validators.max(10000), Validators.min(0)]]
    },{
      validator: IsFoodTitleTaken(this.service, this.restaurantId, this.food.id)
    });
  }

  get f() { return this.registerForm.controls; }

  public onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    let cost = this.registerForm.controls['cost'].value ? this.registerForm.controls['cost'].value : 0;
    if (this.food.id === undefined) {
      let createFoodCommand = new AddFoodVm();
      createFoodCommand.id = this.food.id;
      createFoodCommand.title = this.registerForm.controls['title'].value;
      createFoodCommand.description = this.registerForm.controls['description'].value;
      createFoodCommand.cost = cost;
      this.service.food(this.restaurantId, createFoodCommand).subscribe(
        res => {
          this.restaurantFoodsComponent.refreshFoodsList();
          this.bsModalRef.hide();
        },
        err => {
          console.log(err);
        }
      )
    }
    else {
      let updateFoodCommand = new EditFoodVm();
      updateFoodCommand.id = this.food.id;
      updateFoodCommand.title = this.registerForm.controls['title'].value;
      updateFoodCommand.description = this.registerForm.controls['description'].value;
      updateFoodCommand.cost = cost;
      this.service.food2(this.restaurantId, updateFoodCommand).subscribe(
        res => {
          this.restaurantFoodsComponent.refreshFoodsList();
          this.bsModalRef.hide();
        },
        err => {
          console.log(err);
        }
      )
    }
  }

  public closeModal() {
    this.bsModalRef.hide();
  }
}
