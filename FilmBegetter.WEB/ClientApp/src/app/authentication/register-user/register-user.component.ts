import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { RegistrationViewModel } from "../../shared/models/registrationViewModel.interface";
import { HttpErrorResponse } from "@angular/common/http";


@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {

    registerForm: FormGroup;

    constructor(private authService: AuthenticationService) {
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
    }

    public validateControl = (controlName: string) => {
        return this.registerForm.get(controlName)?.invalid && this.registerForm.get(controlName)?.touched;
    }

    public hasError = (controlName: string, errorName: string) => {
        return this.registerForm.get(controlName)?.hasError(errorName)
    }

    public registerUser = (registerFormValue: any) => {

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
                next: (_) => console.log("Successful registration"),
                error: (err: HttpErrorResponse) => console.log(err.error.errors)
            })
    }
}
