import { Component, OnInit } from '@angular/core';
import { Service, UserVm, CreateUserCommand, UpdateUserCommand } from '../api/api.client.generated';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsersListComponent } from '../users-list/users-list.component';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: []
})
export class UserComponent implements OnInit {
  public user: UserVm;
  public usersListComponent: UsersListComponent;
  registerForm: FormGroup;
  submitted = false;

  constructor(private bsModalRef: BsModalRef, private service: Service, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      name: [this.user.name, [Validators.required]],
      phoneNumber: [this.user.phoneNumber, [Validators.required, Validators.minLength(11), Validators.pattern("^[0-9]*$")]],
      bankName: [this.user.bankName]
    });
  }

  get f() { return this.registerForm.controls; }

  public onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    if (this.user.id === undefined) {
      let createUserCommand = new CreateUserCommand();
      createUserCommand.id = this.user.id;
      createUserCommand.name = this.registerForm.controls['name'].value;
      createUserCommand.phoneNumber = this.registerForm.controls['phoneNumber'].value;
      createUserCommand.bankName = this.registerForm.controls['bankName'].value;
      this.service.user2(createUserCommand).subscribe(
        res => {
          this.usersListComponent.refreshList();
          this.bsModalRef.hide();
        },
        err => {
          console.log(err);
        }
      )
    }
    else {
      let updateUserCommand = new UpdateUserCommand();
      updateUserCommand.id = this.user.id;
      updateUserCommand.name = this.registerForm.controls['name'].value;
      updateUserCommand.phoneNumber = this.registerForm.controls['phoneNumber'].value;
      updateUserCommand.bankName = this.registerForm.controls['bankName'].value;
      this.service.user3(updateUserCommand).subscribe(
        res => {
          this.usersListComponent.refreshList();
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
