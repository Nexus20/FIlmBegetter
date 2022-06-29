import { Component, OnInit } from '@angular/core';
import { MovieViewModel } from "../../../models/movieViewModel.interface";
import { MovieService } from "../../../services/movie.service";
import { MovieOrderType } from "../../../../shared/enums/movieOrderType";
import { HttpErrorResponse } from "@angular/common/http";
import { CSelectionPage } from "../../selection/selection.config";
import { IMovieCard } from "../../../../shared/models/card.interface";

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss']
})
export class CatalogComponent implements OnInit {

    bestCurrentYearMovies!: IMovieCard[];
    bestCurrentYearMoviesQueryParams: object;

    bestMoviesOfAllTime!: IMovieCard[];
    bestMoviesOfAllTimeQueryParams: object;

    bestComedies!: IMovieCard[];
    bestComediesQueryParams: object;

    bestHorrors!: IMovieCard[];
    bestHorrorsQueryParams: object;

    bestForChildren!: IMovieCard[];
    bestForChildrenQueryParams: object;

    bestMysteries!: IMovieCard[];
    bestMysteriesQueryParams: object;

    public selectionConfig = CSelectionPage;

    constructor(private movieService: MovieService) {
        this.bestCurrentYearMoviesQueryParams = { takeCount: 8, orderTypes: [MovieOrderType.RatingDesc], year: new Date().getFullYear()};
        this.bestMoviesOfAllTimeQueryParams   = { takeCount: 8, orderTypes: [MovieOrderType.RatingDesc] };
        this.bestComediesQueryParams          = { takeCount: 8, orderTypes: [MovieOrderType.RatingDesc], genres: ['Comedy'] };
        this.bestHorrorsQueryParams           = { takeCount: 8, orderTypes: [MovieOrderType.RatingDesc], genres: ['Horror'] };
        this.bestForChildrenQueryParams       = { takeCount: 8, orderTypes: [MovieOrderType.RatingDesc], genres: ['Children'] };
        this.bestMysteriesQueryParams         = { takeCount: 8, orderTypes: [MovieOrderType.RatingDesc], genres: ['Mystery'] };
    }

    ngOnInit(): void {
        this.getBestCurrentYearMovies();
        this.getBestMoviesOfAllTime();
        this.getBestMysteriesOfAllTime();
        this.getBestForChildrenOfAllTime();
        this.getBestHorrorsOfAllTime();
        this.getBestComediesOfAllTime();
    }

    private getBestMysteriesOfAllTime() {

        this.movieService.getMovies('api/movies', this.bestMysteriesQueryParams).subscribe({
            next: (data: MovieViewModel[]) => {
                this.bestMysteries = data.map((element) => {
                    return {
                        type: 'smallPreview' as 'smallPreview',
                        info: element
                    }
                });
            },
            error: (err: HttpErrorResponse) => {
                console.log(err)
            }
        });
    }

    private getBestForChildrenOfAllTime() {

        this.movieService.getMovies('api/movies', this.bestForChildrenQueryParams).subscribe({
            next: (data: MovieViewModel[]) => {
                this.bestForChildren = data.map((element) => {
                    return {
                        type: 'smallPreview' as 'smallPreview',
                        info: element
                    }
                });
            },
            error: (err: HttpErrorResponse) => {
                console.log(err)
            }
        });
    }

    private getBestHorrorsOfAllTime() {

        this.movieService.getMovies('api/movies', this.bestHorrorsQueryParams).subscribe({
            next: (data: MovieViewModel[]) => {
                this.bestHorrors = data.map((element) => {
                    return {
                        type: 'smallPreview' as 'smallPreview',
                        info: element
                    }
                });
            },
            error: (err: HttpErrorResponse) => {
                console.log(err)
            }
        });
    }

    private getBestComediesOfAllTime() {

        this.movieService.getMovies('api/movies', this.bestComediesQueryParams).subscribe({
            next: (data: MovieViewModel[]) => {
                console.log(data);
                this.bestComedies = data.map((element) => {
                    return {
                        type: 'smallPreview' as 'smallPreview',
                        info: element
                    }
                });
            },
            error: (err: HttpErrorResponse) => {
                console.log(err)
            }
        });
    }

    private getBestMoviesOfAllTime() {

        this.movieService.getMovies('api/movies', this.bestMoviesOfAllTimeQueryParams).subscribe({
            next: (data: MovieViewModel[]) => {
                console.log(data);
                this.bestMoviesOfAllTime = data.map((element) => {
                    return {
                        type: 'smallPreview' as 'smallPreview',
                        info: element
                    }
                });
                console.log(this.bestMoviesOfAllTime);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err)
            }
        });
    }

    private getBestCurrentYearMovies() {

        this.movieService.getMovies('api/movies', this.bestCurrentYearMoviesQueryParams).subscribe({
            next: (data: MovieViewModel[]) => {
                console.log(data);
                this.bestCurrentYearMovies = data.map((element) => {
                    return {
                        type: 'smallPreview' as 'smallPreview',
                        info: element
                    }
                });
                console.log(this.bestCurrentYearMovies);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err)
            }
        });
    }
}
