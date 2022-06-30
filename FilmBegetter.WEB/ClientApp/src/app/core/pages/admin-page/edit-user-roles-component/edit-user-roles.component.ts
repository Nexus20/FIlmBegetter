import { Component, OnInit } from '@angular/core';
import { ISideMenu } from "../../../../shared/components/side-menu/side-menu.interface";
import { UserViewModel } from "../../../models/user-view-model.interface";
import { routes } from '../admin-routes.config';
import { ActivatedRoute } from "@angular/router";
import { UserService } from "../../../services/user.service";
import { HttpErrorResponse } from "@angular/common/http";
import { RoleViewModel } from "../../../models/role-view-model.interface";
import { RoleService } from "../../../services/role.service";
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { IButton } from "../../../../shared/models/button.interface";
import {UpdateUserRolesViewModel} from "../../../models/update-user-roles-view-model.interface";

@Component({
    selector: 'app-edit-user-roles-component',
    templateUrl: './edit-user-roles.component.html',
    styleUrls: ['./edit-user-roles.component.scss']
})
export class EditUserRolesComponent implements OnInit {

    public routes: ISideMenu[] = routes;

    private userId!: string;

    user!: UserViewModel;

    roles!: RoleViewModel[];

    rolesForm!: FormGroup;

    submitButtonConfig: IButton = {
        type: 'success',
        size: 'default',
        text: 'Apply changes',
        disabled: false
    };

    constructor(private route: ActivatedRoute,
                private formBuilder: FormBuilder,
                private userService: UserService,
                private roleService: RoleService) {
    }

    ngOnInit(): void {

        this.initForm();

        this.route.params.subscribe(params => {
            this.userId = params.id;
            this.getUser();
        });

        this.getRoles();
    }

    public getUser = () => {
        this.userService.getUser(`api/users/${this.userId}`).subscribe({
            next: (data: UserViewModel) => {
                this.user = data;
                console.log(this.user)
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

    public getRoles = () => {
        this.roleService.getRoles('api/roles').subscribe({
            next: (data: RoleViewModel[]) => {
                this.roles = data;
                console.log(this.roles);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

    private initForm() {
        this.rolesForm = new FormGroup({
            roles: this.formBuilder.array([], [Validators.required]),
        });

        const checkboxes: FormArray = this.rolesForm.get('roles') as FormArray;
        checkboxes.push(new FormControl('User'));
    }

    sendForm(formValue: any) {

        const body: UpdateUserRolesViewModel = {
            roles: formValue.roles,
            userId: this.userId
        };

        console.log(body);

        this.userService.updateRoles(`api/users/${this.userId}/update-roles`, body).subscribe({
            next: (data: any) => {
                console.log(data);
            },
            error: (error: HttpErrorResponse) => {
                console.log(error);
            }
        });
    }

    onRoleSelect(event: any) {

        const checkboxes: FormArray = this.rolesForm.get('roles') as FormArray;

        console.log(checkboxes);

        if (event.target.checked) {
            checkboxes.push(new FormControl(event.target.value));
        } else {
            let i: number = 0;
            checkboxes.controls.forEach((item: any) => {
                if (item.value == event.target.value) {
                    checkboxes.removeAt(i);
                    return;
                }
                i++;
            });
        }
    }

    hasRole(roleName: string) {
        return this.user.roles.map(e => e.name).includes(roleName);
    }
}
