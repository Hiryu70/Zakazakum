import { Component, OnInit } from '@angular/core';
import { Service, LoginUserQuery } from '../api/api.client.generated';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthGuard } from '../auth/auth.guard';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {
  registerForm: FormGroup;

  constructor(private service: Service, private formBuilder: FormBuilder, private router: Router, private authGuard: AuthGuard) { }

  ngOnInit() {
    if (this.authGuard.canActivate){
      this.router.navigateByUrl('/');
    }

    this.registerForm = this.formBuilder.group({
      phoneNumber: ['', [Validators.required, Validators.minLength(11), Validators.pattern("^[0-9]*$")]],
      password: ['', [Validators.required, Validators.minLength(4)]],
    });
  }

  get f() { return this.registerForm.controls; }

  public registration() {
    this.router.navigateByUrl('/registration');
  }

  public onSubmit() {
    if (this.registerForm.invalid) {
      return;
    }

    let registerUser = new LoginUserQuery();
    registerUser.phoneNumber = this.registerForm.controls['phoneNumber'].value;
    registerUser.password = this.registerForm.controls['password'].value;
    this.service.login(registerUser).subscribe(
      res => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/');
      },
      err => {
        console.log(err);
      }
    )
  }
}
