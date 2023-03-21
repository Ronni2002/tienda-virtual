import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  Login!: FormGroup;

  constructor(private fb: FormBuilder, private services: AuthService, private route: Router){
    localStorage.clear();
  }

  ngOnInit(): void {
    this.Login = this.fb.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });
  }

  submitForm(): void {
    if (this.Login.valid) {
      this.services.post(this.Login.value, 'Login').subscribe(result => {
        if(result != null){
          localStorage.setItem('token', `${result.token}`)
          this.route.navigate(['/products/list'])
        }
      });
    } else {
      Object.values(this.Login.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }
}
