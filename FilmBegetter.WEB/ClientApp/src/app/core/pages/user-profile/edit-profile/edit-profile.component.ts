import { Component, OnInit } from '@angular/core';
import { UserViewModel } from "../../../models/user-view-model.interface";
import { UserService } from "../../../services/user.service";
import { HttpErrorResponse } from "@angular/common/http";
import { FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

    editUserForm: FormGroup;

    user!: UserViewModel;

    errorMessage: string = '';
    showError: boolean = false;

    constructor(private userService: UserService) {

        this.editUserForm = new FormGroup({
            id: new FormControl('', [Validators.required]),
            name: new FormControl('', [Validators.required]),
            surname: new FormControl('', [Validators.required]),
            email: new FormControl('', [Validators.required, Validators.email])
        })
    }

    ngOnInit(): void {
        this.getUserProfile();
    }

    validateControl = (controlName: string) => {
        return this.editUserForm.get(controlName)?.invalid && this.editUserForm.get(controlName)?.touched
    }

    hasError = (controlName: string, errorName: string) => {
        return this.editUserForm.get(controlName)?.hasError(errorName)
    }

    getUserProfile = () => {
        this.userService.getCurrentUser("api/users/currentUser").subscribe({

            next: (data: UserViewModel) => {
                this.user = data;

                this.editUserForm = new FormGroup({
                    id: new FormControl(this.user.id, [Validators.required]),
                    name: new FormControl(this.user.name, [Validators.required]),
                    surname: new FormControl(this.user.surname, [Validators.required]),
                    email: new FormControl(this.user.email, [Validators.required, Validators.email])
                })
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }

        });
    }

    editUser = (editUserFormValue: any) => {

        this.userService.updateCurrentUser("api/users/update", editUserFormValue).subscribe({

            next: (res: any) => {

                this.getUserProfile();
            },

            error: (err: HttpErrorResponse) => {
                this.errorMessage = err.message;
                this.showError = true;
            }
        });
    }
}
