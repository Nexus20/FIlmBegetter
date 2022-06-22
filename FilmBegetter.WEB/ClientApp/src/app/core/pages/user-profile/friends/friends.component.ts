import { Component, OnInit } from '@angular/core';
import { UserViewModel } from "../../../models/user-view-model.interface";
import { HttpErrorResponse } from "@angular/common/http";
import { UserService } from "../../../services/user.service";

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {

    user!: UserViewModel;

    searchInput =  {
        placeholder: "Find users by name, surname or email",
        icon: "search-normal",
        type: "default" as "default",
        isdisabled: false
    };

    constructor(private userService: UserService) { }

    ngOnInit(): void {
        this.getUserProfile();
    }

    getUserProfile = () => {
        this.userService.getCurrentUser("api/users/currentUser").subscribe({

            next: (data: UserViewModel) => {
                this.user = data;
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }

        });
    }

    getUsersByName(event: any) {

        let username = event.target.value;

        this.userService.getUsers('api/users/', {name: username, email: username}).subscribe({

            next: (data: UserViewModel[]) => {
                console.log(data)
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }
}
