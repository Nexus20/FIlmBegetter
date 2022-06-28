import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "../../shared/services/environment-url.service";
import { UserViewModel } from "../models/user-view-model.interface";
import { SubscriptionChangeResponse } from "../models/subscription-change-response.interface";
import {UserToUpdateViewModel} from "../models/user-to-update-view-model.interface";

@Injectable({
  providedIn: 'root'
})
export class UserService {

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public getUsers = (route: string, queryParams?: {}) => {
        return this.http.get<UserViewModel[]>(this.createCompleteRoute(route, this.envUrl.urlAddress), {params: queryParams});
    }

    public getUser = (route: string) => {
        return this.http.get<UserViewModel>(this.createCompleteRoute(route, this.envUrl.urlAddress));
    }

    public getCurrentUser(route: string) {
        return this.http.get<UserViewModel>(this.createCompleteRoute(route, this.envUrl.urlAddress));
    }

    public updateUserSubscription(route: string, body: SubscriptionChangeResponse) {

        return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    public updateCurrentUser(route: string, body: UserToUpdateViewModel) {

        return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
