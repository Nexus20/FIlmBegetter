import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {UserService} from "../../../services/user.service";
import {UserViewModel} from "../../../models/user-view-model.interface";
import {HttpErrorResponse} from "@angular/common/http";
import {ISideMenu} from "../../../../shared/components/side-menu/side-menu.interface";
import {routes} from '../admin-routes.config';
import {IButton} from "../../../../shared/models/button.interface";

@Component({
    selector: 'app-view-user-profile-component',
    templateUrl: './view-user-profile-component.component.html',
    styleUrls: ['./view-user-profile-component.component.scss']
})
export class ViewUserProfileComponentComponent implements OnInit {

    public routes: ISideMenu[] = routes;

    private userId!: string;

    user!: UserViewModel;

    editRolesBtnConfig: IButton = {
        disabled: false,
        size: "default",
        text: "Edit user roles",
        type: "default",
        href: "edit-roles"
    };

    constructor(private route: ActivatedRoute,
                private userService: UserService) {}

    ngOnInit(): void {

        this.route.params.subscribe(params => {
            this.userId = params.id;

            console.log(this.userId);

            this.getUser();
        });
    }

    public getUser = () => {
        this.userService.getUser(`api/users/${this.userId}`).subscribe({
            next: (data: UserViewModel) => {
                console.log(data);
                this.user = data;
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

}
