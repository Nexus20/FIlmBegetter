import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {EnvironmentUrlService} from "../../shared/services/environment-url.service";
import {GenreViewModel} from "../models/genreViewModel.interface";

@Injectable({
  providedIn: 'root'
})
export class GenreService {

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public getGenres = (route: string, queryParams?: {}) => {
        return this.http.get<GenreViewModel[]>(this.createCompleteRoute(route, this.envUrl.urlAddress), {params: queryParams});
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
