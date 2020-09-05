import { Component, OnInit } from '@angular/core';
import { Service, UserVm, CreateUserCommand } from '../api/api.client.generated';
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
      phoneNumber: [this.user.phoneNumber, [Validators.required, Validators.minLength(11)]]
    });
  }

  get f() { return this.registerForm.controls; }

  public onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    let createStudentCommand = new CreateUserCommand();
    createStudentCommand.id = this.user.id;
    createStudentCommand.name = this.registerForm.controls['name'].value;
    createStudentCommand.phoneNumber = this.registerForm.controls['phoneNumber'].value;
    this.service.user2(createStudentCommand).subscribe(
      res => {
        this.usersListComponent.refreshList();
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
