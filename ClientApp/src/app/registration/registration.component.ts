import { Component, OnInit } from '@angular/core';
import { Service, RegisterUserCommand } from '../api/api.client.generated';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IsPhoneNumberTaken } from '../validators/is-phone-number-taken.validator';
import { IsPasswordsEqual } from '../validators/is-passwords-equal.validator';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {
  registerForm: FormGroup;

  constructor(private service: Service, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      bankName: [''],
      phoneNumber: ['', [Validators.required, Validators.minLength(11), Validators.pattern("^[0-9]*$")]],
      password: ['', [Validators.required, Validators.minLength(4)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(4)]]
    },{
      validators: [IsPhoneNumberTaken(this.service, '00000000-0000-0000-0000-000000000000'), IsPasswordsEqual()]
    });

    this.registerForm.controls['password'].valueChanges.subscribe(() => {
      this.registerForm.controls['confirmPassword'].updateValueAndValidity();
    })
  }

  get f() { return this.registerForm.controls; }

  public onSubmit() {
    if (this.registerForm.invalid) {
      return;
    }

    let registerUser = new RegisterUserCommand();
    registerUser.name = this.registerForm.controls['name'].value;
    registerUser.phoneNumber = this.registerForm.controls['phoneNumber'].value;
    registerUser.bankName = this.registerForm.controls['bankName'].value;
    registerUser.password = this.registerForm.controls['password'].value;
    this.service.register(registerUser).subscribe(
      res => {
          this.registerForm.reset();
      },
      err => {
        console.log(err);
      }
    )
  }

}
