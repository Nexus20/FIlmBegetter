import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {AuthenticationService, UserAuthenticationInfo} from "../../shared/services/authentication.service";
import { HttpErrorResponse } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationViewModel } from "../../core/models/authenticationViewModel.interface";
import { AuthenticationResponseViewModel } from "../../core/models/authenticationResponseViewModel.interface";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private returnUrl: string = '';

  loginForm!: FormGroup;
  errorMessage: string = '';
  showError: boolean = false;

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  validateControl = (controlName: string) => {
    return this.loginForm.get(controlName)?.invalid && this.loginForm.get(controlName)?.touched
  }

  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName)?.hasError(errorName)
  }

  loginUser = (loginFormValue: any) => {

    this.showError = false;
    const login = { ...loginFormValue };

    const userForAuth: AuthenticationViewModel = {
      email: login.username,
      password: login.password
    }

    this.authService.loginUser('api/accounts/login', userForAuth)
      .subscribe({
        next: (res: AuthenticationResponseViewModel) => {
          localStorage.setItem("token", res.token);

            const obj: UserAuthenticationInfo = {
                isAuthenticated: res.isAuthSuccessful,
                isAdmin: this.authService.isUserAdmin(),
                isModer: this.authService.isUserModerator()
            };

          this.authService.sendAuthStateChangeNotification(obj);
          this.router.navigate([this.returnUrl]);
        },
        error: (err: HttpErrorResponse) => {
          this.errorMessage = err.message;
          this.showError = true;
        }
      });
  }
}
