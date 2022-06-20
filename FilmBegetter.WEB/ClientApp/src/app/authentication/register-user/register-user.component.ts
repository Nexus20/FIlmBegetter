import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from "@angular/forms";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { HttpErrorResponse } from "@angular/common/http";
import {
  PasswordConfirmationValidatorService
} from "../../shared/custom-validators/password-confirmation-validator.service";
import { Router} from "@angular/router";
import { RegistrationViewModel} from "../../core/models/registrationViewModel.interface";


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {

    public registerForm: FormGroup;
    public errorMessage: string = '';
    public showError: boolean = false;

    constructor(private authService: AuthenticationService, private passConfValidator: PasswordConfirmationValidatorService, private router: Router) {
        this.registerForm = new FormGroup({}, undefined, undefined);
    }

    ngOnInit(): void {
        this.registerForm = new FormGroup({
            firstName: new FormControl(''),
            lastName: new FormControl(''),
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required]),
            confirm: new FormControl('')
        });
        this.registerForm.get('confirm')?.setValidators([
          Validators.required,
          this.passConfValidator.validateConfirmPassword(<AbstractControl>this.registerForm.get('password'))
        ]);
    }

    public validateControl = (controlName: string) => {
        return this.registerForm.get(controlName)?.invalid && this.registerForm.get(controlName)?.touched;
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.registerForm.get(controlName)?.hasError(errorName)
    }

    public registerUser = (registerFormValue: any) => {

        this.showError = false;

        const formValues = { ...registerFormValue };

        const user: RegistrationViewModel = {
            firstName: formValues.firstName,
            lastName: formValues.lastName,
            email: formValues.email,
            password: formValues.password,
            confirmPassword: formValues.confirm
        };

        this.authService.registerUser("api/accounts/registration", user)
            .subscribe({
                next: (_) => this.router.navigate(["/authentication/login"]),
                error: (err: HttpErrorResponse) => {
                    this.errorMessage = err.message;
                    this.showError = true;
                }
            })
    }
}
