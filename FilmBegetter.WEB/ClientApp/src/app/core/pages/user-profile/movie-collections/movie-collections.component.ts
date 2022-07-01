import { Component, OnInit } from '@angular/core';
import { UserViewModel } from "../../../models/user-view-model.interface";
import { UserService } from "../../../services/user.service";
import { HttpErrorResponse } from "@angular/common/http";
import {ISideMenu} from "../../../../shared/components/side-menu/side-menu.interface";
import { routes } from '../user-profile-routes.config';
import {ICollectionCard} from "../../../../shared/models/card-collection.interface";
import {MovieCollectionViewModel} from "../../../models/movie-collection-view-model.interface";

@Component({
  selector: 'app-movie-collections',
  templateUrl: './movie-collections.component.html',
  styleUrls: ['./movie-collections.component.scss']
})
export class MovieCollectionsComponent implements OnInit {

    public routes: ISideMenu[] = routes;

    movieCollectionCards!: ICollectionCard[];

    user!: UserViewModel;

    constructor(private userService: UserService) { }

    ngOnInit(): void {
        this.getUserProfile();
    }

    getUserProfile = () => {
        this.userService.getCurrentUser("api/users/currentUser").subscribe({

            next: (data: UserViewModel) => {
                this.user = data;
                this.movieCollectionCards = this.user.movieCollections.map(e => <ICollectionCard>{
                    type: 'collection',
                    info: e
                });
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }
}
