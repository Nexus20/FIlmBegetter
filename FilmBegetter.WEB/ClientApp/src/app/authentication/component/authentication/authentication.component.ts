import { ValidationErrors, ValidatorFn } from '@angular/forms';
import { PasswordConfirmationValidatorService } from './../../../shared/custom-validators/password-confirmation-validator.service';
import { FormBuilder, FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

import { AuthenticationResponseViewModel } from './../../../core/models/authenticationResponseViewModel.interface';
import { AuthenticationService, UserAuthenticationInfo } from './../../../shared/services/authentication.service';
import { DIALOG_DATA } from './../../../shared/components/dialog/dialog-token';
import { DialogRef } from './../../../shared/components/dialog/dialog-ref';
import { IButton } from './../../../shared/models/button.interface';
import { IInput } from './../../../shared/models/input.interface';


@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss']
})
export class AuthenticationComponent implements OnInit {

  public isLogginMode: boolean = false;
  public loginForm!: FormGroup;
  public registerForm!: FormGroup;
  public error!: string | null;
  public passwordPattern: string = "Your Password must contain: \n- 8 characters or more \n- 1 uppercase character (A-Z) \n- 1 lowercase character (a-z) \n- 1 number (0 -9) \n- 1 special character (! @ # ? ])";

  constructor(
    private dialogRef: DialogRef,
    @Inject(DIALOG_DATA) public data: { state: boolean },
    private fb: FormBuilder,
    private authService: AuthenticationService,
    private passConfValidator: PasswordConfirmationValidatorService
  ) { }

  ngOnInit(): void {
    this.isLogginMode = this.data.state;
    this.initForm();
  }

  public loginConfig: IInput = {
    type: 'default',
    placeholder: 'Username..',
    isdisabled: false,
    icon: 'person',
  }

  public surnameConfig: IInput = {
    type: 'default',
    placeholder: 'Surname..',
    isdisabled: false,
    icon: 'person',
  }

  public emailConfig: IInput = {
    type: 'default',
    placeholder: 'Email..',
    isdisabled: false,
    icon: 'sms',
  }

  public passwordConfig: IInput = {
    type: 'default',
    placeholder: 'Password..',
    isdisabled: false,
    icon: 'lock',
  }

  public confirmPasswordConfig: IInput = {
    type: 'default',
    placeholder: 'Confirm password..',
    isdisabled: false,
    icon: 'lock',
  }

  public submitButton: IButton = {
    type: 'default',
    size: 'default',
    text: 'Create an account',
    disabled: false
  }

  public authByGoogle: IButton = {
    type: 'default',
    size: 'small',
    text: 'Sign Up with Google',
    disabled: false,
    unactive: true,
  }

  public errorButton: IButton = {
    type: 'danger',
    size: 'small',
    text: 'OK',
    disabled: false,
  }


  get password(): FormControl {
    if (this.isLogginMode) {
      return this.loginForm.get('password') as FormControl;
    }
    else {
      return this.registerForm.get('password') as FormControl;
    }
  }

  get email(): FormControl {
    if (this.isLogginMode) {
      return this.loginForm.get('email') as FormControl;
    }
    else {
      return this.registerForm.get('email') as FormControl;
    }
  }

  get surname(): FormControl {
    return this.registerForm.get('surname') as FormControl;
  }
  get username(): FormControl {
    return this.registerForm.get('username') as FormControl;
  }
  get confirmPassword(): FormControl {
    return this.registerForm.get('confirmPassword') as FormControl;
  }

  public changeState(): void {
    this.isLogginMode = !this.isLogginMode;
    if (!this.loginForm || !this.registerForm) {
      this.initForm();
    }
  }

  public close(): void {
    this.dialogRef.close();
  }

  public onSubmit(): void {
    if (this.isLogginMode) {
      if (this.loginForm.valid) {
        this._login();
      }
    }
    else {
      if (this.registerForm.valid) {
        this._registration();
      }
    }
  }

  public setError(controller: IInput, control: FormControl): void {
    if (control.errors) {
      let errorMessage = '';
      if (control.errors.required) {
        errorMessage = 'Field is required'
      }
      else if (control.errors.email) {
        errorMessage = 'Incorrect email form'
      }
      controller.error = errorMessage;
    }
    else {
      controller.error = '';
    }
  }

  public initForm(): void {
    if (this.isLogginMode) {
      this.loginForm = this.fb.group({
        email: this.fb.control("", [Validators.required, Validators.email]),
        password: this.fb.control("", [Validators.required])
      })
    }
    else {
      this.registerForm = this.fb.group({
        username: this.fb.control("", []),
        surname: this.fb.control("", []),
        email: this.fb.control("", [Validators.required, Validators.email]),
        password: this.fb.control("", [Validators.required, Validators.pattern(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W|_).{8,}$/gm)]),
        confirmPassword: this.fb.control("", []),
      },
        {
          validators: this.passConfValidator.checkPasswords
        })
    }
  }

  private _login(): void {
    const value = this.loginForm.value;

    this.authService.loginUser('api/accounts/login', { email: value.email, password: value.password })
      .subscribe({
        next: (res: AuthenticationResponseViewModel) => {
          localStorage.setItem("token", res.token);

          const obj: UserAuthenticationInfo = {
            isAuthenticated: res.isAuthSuccessful,
            isAdmin: this.authService.isUserAdmin(),
            isModer: this.authService.isUserModerator()
          };

          this.authService.sendAuthStateChangeNotification(obj);
          this.dialogRef.close();
          this.loginForm.reset();
          this.loginForm.markAllAsTouched();
        },
        error: (err: HttpErrorResponse) => {
          this.error = err.message;
        }
      });
  }

  private _registration(): void {
    const { username: firstName, surname: lastName, email, password, confirmPassword } = this.registerForm.value;

    this.authService.registerUser("api/accounts/registration", { firstName, lastName, email, password, confirmPassword })
      .subscribe({
        next: (_) => this.changeState(),
        error: (err: HttpErrorResponse) => {
          this.error = err.message;
        }
      })
  }
}
