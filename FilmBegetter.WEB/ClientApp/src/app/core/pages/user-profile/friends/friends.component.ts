import {Component, OnInit} from '@angular/core';
import {UserViewModel} from "../../../models/user-view-model.interface";
import {HttpErrorResponse} from "@angular/common/http";
import {UserService} from "../../../services/user.service";
import {FriendRequestsService} from "../../../services/friend-requests.service";
import {FriendRequestToCreateViewModel} from "../../../models/friendRequestToCreateViewModel.interface";

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent implements OnInit {

    user!: UserViewModel;

    friendsSearchResults: UserViewModel[] = [];

    searchInput =  {
        placeholder: "Find users by name, surname or email",
        icon: "search-normal",
        type: "default" as "default",
        isdisabled: false
    };

    constructor(private userService: UserService, private friendRequestsService: FriendRequestsService) { }

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
        console.log(username);

        if(username === '') {
            this.friendsSearchResults = [];
            return;
        }

        this.userService.getUsers('api/users/', {name: username, email: username}).subscribe({

            next: (data: UserViewModel[]) => {

                if(data.length) {
                    this.friendsSearchResults = data.filter(val => val.id != this.user.id);
                }
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

    sendFriendRequest(event: any, recipientId: string) {

        const body: FriendRequestToCreateViewModel = {
            senderId: this.user.id,
            recipientId: recipientId
        }

        this.friendRequestsService.create("api/friendRequests", body).subscribe({
                next: (data: any) => {
                    console.log(data);
                },
                error: (error: HttpErrorResponse) => {
                    console.log(error)
                }
            }
        );

        console.log(recipientId, event);
    }
}
