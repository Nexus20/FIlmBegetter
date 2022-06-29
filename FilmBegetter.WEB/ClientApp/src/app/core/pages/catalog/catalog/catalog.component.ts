import { Component, OnInit } from '@angular/core';
import {MovieViewModel} from "../../../models/movieViewModel.interface";
import {MovieService} from "../../../services/movie.service";
import {MovieOrderType} from "../../../../shared/enums/movieOrderType";
import {MovieViewModule} from "../../movie-view/movie-view.module";
import {HttpErrorResponse} from "@angular/common/http";
import {CSelectionPage} from "../../selection/selection.config";
import {IMovieCard} from "../../../../shared/models/card.interface";

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss']
})
export class CatalogComponent implements OnInit {

    bestCurrentYearMovies!: IMovieCard[];
    bestMoviesOfAllTime!: IMovieCard[];
    bestComedies!: IMovieCard[];
    bestHorrors!: IMovieCard[];
    bestForChildren!: IMovieCard[];
    bestMysteries!: IMovieCard[];

    public selectionConfig = CSelectionPage;

    constructor(private movieService: MovieService) {}

    ngOnInit(): void {
        this.getBestCurrentYearMovies();
        this.getBestMoviesOfAllTime();
        this.getBestMysteriesOfAllTime();
        this.getBestForChildrenOfAllTime();
        this.getBestHorrorsOfAllTime();
        this.getBestComediesOfAllTime();
    }

    private getBestMysteriesOfAllTime() {

        const queryParams = {
            takeCount: 8,
            orderTypes: [MovieOrderType.RatingDesc],
            genres: ['Mystery']
        }

        this.movieService.getMovies('api/movies', queryParams).subscribe({
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

        const queryParams = {
            takeCount: 8,
            orderTypes: [MovieOrderType.RatingDesc],
            genres: ['Children']
        }

        this.movieService.getMovies('api/movies', queryParams).subscribe({
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

        const queryParams = {
            takeCount: 8,
            orderTypes: [MovieOrderType.RatingDesc],
            genres: ['Horror']
        }

        this.movieService.getMovies('api/movies', queryParams).subscribe({
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

        const queryParams = {
            takeCount: 8,
            orderTypes: [MovieOrderType.RatingDesc],
            genres: ['Comedy']
        }

        this.movieService.getMovies('api/movies', queryParams).subscribe({
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

        const queryParams = {
            takeCount: 8,
            orderTypes: [MovieOrderType.RatingDesc],
        }

        this.movieService.getMovies('api/movies', queryParams).subscribe({
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

        const queryParams = {
            takeCount: 8,
            year: new Date().getFullYear(),
            orderTypes: [MovieOrderType.RatingDesc],
        }

        this.movieService.getMovies('api/movies', queryParams).subscribe({
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
