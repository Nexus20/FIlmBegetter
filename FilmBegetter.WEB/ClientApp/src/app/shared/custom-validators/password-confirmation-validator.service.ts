import { Injectable } from '@angular/core';
import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class PasswordConfirmationValidatorService {

  constructor() { }

  public checkPasswords: ValidatorFn = (group: AbstractControl): ValidationErrors | null => {
    let pass = group.get('password')?.value;
    let confirmPass = group.get('confirmPassword')?.value
    return pass === confirmPass ? null : { mustMatch: true }
  }

  public validateConfirmPassword = (passwordControl: AbstractControl): ValidatorFn => {

    return (confirmationControl: AbstractControl): { [key: string]: boolean } | null => {
      if (confirmationControl && passwordControl) {

        const confirmValue = confirmationControl.value;
        const passwordValue = passwordControl.value;

        if (confirmValue !== passwordValue) {
          return { mustMatch: true }
        }
      }
      return null;
    };
  }
}
