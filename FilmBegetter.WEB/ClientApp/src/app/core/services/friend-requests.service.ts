import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "../../shared/services/environment-url.service";
import { FriendRequestToCreateViewModel } from "../models/friendRequestToCreateViewModel.interface";
import {FriendRequestToUpdateViewModel} from "../models/friendRequestToUpdateViewModel.interface";

@Injectable({
  providedIn: 'root'
})
export class FriendRequestsService {

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public create = (route: string, body: FriendRequestToCreateViewModel) => {
        return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    public changeRequestStatus = (route: string, body: FriendRequestToUpdateViewModel) => {
        return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
