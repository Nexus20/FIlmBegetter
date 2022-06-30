import { ISideMenu } from './../../../../shared/components/side-menu/side-menu.interface';
import { Component, OnInit } from '@angular/core';
import { UserService } from "../../../services/user.service";
import { UserViewModel } from "../../../models/user-view-model.interface";
import { HttpErrorResponse } from "@angular/common/http";
import { routes } from '../user-profile-routes.config';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public user!: UserViewModel;
  public routes: ISideMenu[] = routes;

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
