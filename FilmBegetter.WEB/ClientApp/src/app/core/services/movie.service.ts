import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { MovieViewModel } from "../models/movieViewModel.interface";
import { EnvironmentUrlService } from "../../shared/services/environment-url.service";


@Injectable({
  providedIn: 'root'
})
export class MovieService {

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public getMovies = (route: string, queryParams?: {}) => {
        return this.http.get<MovieViewModel[]>(this.createCompleteRoute(route, this.envUrl.urlAddress), {params: queryParams});
    }

    public create = (route: string, body: FormData) => {
        return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
