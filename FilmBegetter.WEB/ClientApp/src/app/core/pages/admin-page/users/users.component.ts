import { Component, OnInit } from '@angular/core';
import { UserService } from "../../../services/user.service";
import {HttpErrorResponse } from "@angular/common/http";
import {UserViewModel } from "../../../models/user-view-model.interface";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

    constructor(private userService: UserService) { }

    public getUsers = () => {
        this.userService.getUsers("api/users").subscribe({
            next: (data: UserViewModel[]) => {
               console.log(data);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

    ngOnInit(): void {
        this.getUsers();
    }

}
