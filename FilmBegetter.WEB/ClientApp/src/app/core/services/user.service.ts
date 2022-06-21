import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "../../shared/services/environment-url.service";
import { UserViewModel } from "../models/user-view-model.interface";

@Injectable({
  providedIn: 'root'
})
export class UserService {

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public getUsers = (route: string, queryParams?: {}) => {
        return this.http.get<{$id: string, $values: UserViewModel[]}>(this.createCompleteRoute(route, this.envUrl.urlAddress), {params: queryParams});
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}