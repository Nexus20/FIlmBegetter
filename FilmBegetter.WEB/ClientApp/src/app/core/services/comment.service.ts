import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {EnvironmentUrlService} from "../../shared/services/environment-url.service";
import {CommentToCreateViewModel} from "../models/commentToCreateViewModel.interface";
import {CommentViewModel} from "../models/commentViewModel.interface";

@Injectable({
  providedIn: 'root'
})
export class CommentService {

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public create = (route: string, body: CommentToCreateViewModel) => {
        return this.http.post<CommentViewModel>(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
