import { Component, OnInit } from '@angular/core';
import { UserViewModel } from "../../../models/user-view-model.interface";
import { UserService } from "../../../services/user.service";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: 'app-movie-collections',
  templateUrl: './movie-collections.component.html',
  styleUrls: ['./movie-collections.component.css']
})
export class MovieCollectionsComponent implements OnInit {

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
                console.log(this.user.movieCollections);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }
}
