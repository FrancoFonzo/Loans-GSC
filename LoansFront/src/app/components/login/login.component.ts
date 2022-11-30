import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthResponse } from '../../interfaces/authResponse';
import { AuthRequest } from '../../interfaces/authRequest';
import { AuthService } from '../../services/auth.service';
import { NotificationService } from '../../services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  formLogin: FormGroup = this.formBuilder.group({
    username: ["", Validators.required],
    password: ["", Validators.required]
  });

  hide: boolean = true;
  
  constructor(
    private authService: AuthService, private router: Router,
    private formBuilder: FormBuilder, private notification: NotificationService) { }

  ngOnInit(): void {
    
  }

  login(user: AuthRequest): void {
    if (!this.formLogin.valid) {
      this.formLogin.markAllAsTouched();
      return;
    }
    this.authService.login(user).subscribe({
      next: (authResponse: AuthResponse) => {
        this.router.navigate(["/"]);
      }
    });
  }

  isValid(field: string): boolean | undefined {
    return this.formLogin.get(field)?.invalid &&
      this.formLogin.get(field)?.touched;
  }
}
