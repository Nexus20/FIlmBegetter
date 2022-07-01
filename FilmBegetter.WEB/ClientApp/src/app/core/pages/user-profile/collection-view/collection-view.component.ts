import { Component, OnInit } from '@angular/core';
import { ISideMenu } from "../../../../shared/components/side-menu/side-menu.interface";
import { routes } from '../user-profile-routes.config';
import { MovieCollectionViewModel } from "../../../models/movie-collection-view-model.interface";
import { ActivatedRoute } from "@angular/router";
import { HttpErrorResponse } from "@angular/common/http";
import { MovieCollectionService } from "../../../services/movie-collection.service";
import {IMovieCard} from "../../../../shared/models/card.interface";

@Component({
    selector: 'app-collection-view',
    templateUrl: './collection-view.component.html',
    styleUrls: ['./collection-view.component.scss']
})
export class CollectionViewComponent implements OnInit {

    public routes: ISideMenu[] = routes;

    collectionId!: string;

    collection!: MovieCollectionViewModel;

    movieCards!: IMovieCard[];

    constructor(private route: ActivatedRoute, private collectionService: MovieCollectionService) {}

    ngOnInit(): void {
        this.route.params.subscribe(params => {
            this.collectionId = params.id;
            this.getCollection();
        });
    }

    public getCollection = () => {
        this.collectionService.getCollection(`api/collections/${this.collectionId}`).subscribe({
            next: (data: MovieCollectionViewModel) => {
                this.collection = data;
                this.movieCards = this.collection.movies.map(e => <IMovieCard>{
                    info: e,
                    type: "defaultPreview"
                });
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

}
