import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {EnvironmentUrlService} from "../../shared/services/environment-url.service";

@Injectable({
  providedIn: 'root'
})
export class MovieCollectionService {

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public create = (route: string, body: any) => {
        return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    public update = (route: string, body: any) => {
        return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
