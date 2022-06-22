import { Component, OnInit } from '@angular/core';
import { UserService } from "../../../services/user.service";
import { UserViewModel } from "../../../models/user-view-model.interface";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

    user!: UserViewModel;

    constructor(private userService: UserService) { }

    ngOnInit(): void {
        this.getUserProfile();
    }

    getUserProfile = () => {
        this.userService.getCurrentUser("api/users/currentUser").subscribe({

            next: (data: UserViewModel) => {
                this.user = data;
                console.log(this.user);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }

        });
    }
}
