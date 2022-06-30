import { Component, OnInit } from '@angular/core';
import { ISideMenu } from "../../../../shared/components/side-menu/side-menu.interface";
import { UserViewModel } from "../../../models/user-view-model.interface";
import { routes } from '../admin-routes.config';
import { ActivatedRoute } from "@angular/router";
import { UserService } from "../../../services/user.service";
import { HttpErrorResponse } from "@angular/common/http";
import {RoleViewModel} from "../../../models/role-view-model.interface";
import {RoleService} from "../../../services/role.service";

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

    constructor(private route: ActivatedRoute,
                private userService: UserService,
                private roleService: RoleService) {}

    ngOnInit(): void {
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
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }
}
