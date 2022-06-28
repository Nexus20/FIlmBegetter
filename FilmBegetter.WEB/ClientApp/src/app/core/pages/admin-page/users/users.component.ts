import { Component, OnInit } from '@angular/core';
import { UserService } from "../../../services/user.service";
import { HttpErrorResponse } from "@angular/common/http";
import { UserViewModel } from "../../../models/user-view-model.interface";
import { IUserCard } from "../../../../shared/models/card-user.interface";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

    users!: IUserCard[];

    constructor(private userService: UserService) { }

    public getUsers = () => {
        this.userService.getUsers("api/users").subscribe({
            next: (data: UserViewModel[]) => {
               console.log(data);

                this.users = new Array<IUserCard>();

                for (let i = 0; i < data.length; i++) {

                    this.users.push({
                        type: 'user',
                        info: data[i]
                    });
                }

                console.log(this.users);
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
