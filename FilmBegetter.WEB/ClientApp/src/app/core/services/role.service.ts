import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "../../shared/services/environment-url.service";
import { RoleViewModel } from "../models/role-view-model.interface";

@Injectable({
  providedIn: 'root'
})
export class RoleService {

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public getRoles = (route: string, queryParams?: {}) => {
        return this.http.get<RoleViewModel[]>(this.createCompleteRoute(route, this.envUrl.urlAddress), { params: queryParams });
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
