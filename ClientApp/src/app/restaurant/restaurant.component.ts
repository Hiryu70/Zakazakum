import { Component, OnInit } from '@angular/core';
import { Service, RestaurantVm, CreateRestaurantCommand, UpdateRestaurantCommand } from '../api/api.client.generated';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RestaurantsListComponent } from '../restaurants-list/restaurants-list.component';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: []
})
export class RestaurantComponent implements OnInit {
  public restaurant: RestaurantVm;
  public restaurantsListComponent: RestaurantsListComponent;
  registerForm: FormGroup;
  submitted = false;

  constructor(private bsModalRef: BsModalRef, private service: Service, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      title: [this.restaurant.title, [Validators.required]]
    });
  }

  get f() { return this.registerForm.controls; }

  public onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    if (this.restaurant.id === undefined) {
      let createRestaurantCommand = new CreateRestaurantCommand();
      createRestaurantCommand.title = this.registerForm.controls['title'].value;
      this.service.restaurant2(createRestaurantCommand).subscribe(
        res => {
          this.restaurantsListComponent.refreshList();
          this.bsModalRef.hide();
        },
        err => {
          console.log(err);
        }
      )
    }
    else {
      let updateRestaurantCommand = new UpdateRestaurantCommand();
      updateRestaurantCommand.id = this.restaurant.id;
      updateRestaurantCommand.title = this.registerForm.controls['title'].value;
      this.service.restaurant3(updateRestaurantCommand).subscribe(
        res => {
          this.restaurantsListComponent.refreshList();
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
