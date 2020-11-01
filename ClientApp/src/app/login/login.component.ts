import { Component, OnInit } from '@angular/core';
import { Service, ApplicationUserModel } from '../api/api.client.generated';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {
  registerForm: FormGroup;

  constructor(private service: Service, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      phoneNumber: ['', [Validators.required, Validators.minLength(11), Validators.pattern("^[0-9]*$")]],
      password: ['', [Validators.required, Validators.minLength(4)]],
    });
  }

  get f() { return this.registerForm.controls; }

  public onSubmit() {
    if (this.registerForm.invalid) {
      return;
    }

    let registerUser = new ApplicationUserModel();
    registerUser.phoneNumber = this.registerForm.controls['phoneNumber'].value;
    registerUser.password = this.registerForm.controls['password'].value;
    // this.service.register(registerUser).subscribe(
    //   res => {
    //       this.registerForm.reset();
    //   },
    //   err => {
    //     console.log(err);
    //   }
    // )
  }
}
