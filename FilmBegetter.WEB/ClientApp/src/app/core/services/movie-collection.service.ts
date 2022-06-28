import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {EnvironmentUrlService} from "../../shared/services/environment-url.service";
import {MovieCollectionViewModel} from "../models/movie-collection-view-model.interface";
import {AddMovieToCollectionViewModel} from "../models/add-movie-to-collection-view-model.interface";

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

    public getCurrentUserCollections = (route: string) => {
        return this.http.get<MovieCollectionViewModel[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
    }

    public addMovie = (route: string, body: AddMovieToCollectionViewModel) => {
        return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
