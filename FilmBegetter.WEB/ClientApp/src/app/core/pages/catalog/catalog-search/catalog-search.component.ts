import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { MovieViewModel } from "../../../models/movieViewModel.interface";
import { HttpErrorResponse } from "@angular/common/http";
import { MovieService } from "../../../services/movie.service";
import { IMovieCard } from "../../../../shared/models/card.interface";
import { MovieOrderType } from "../../../../shared/enums/movieOrderType";
import { GenreService } from "../../../services/genre.service";
import { GenreViewModel } from "../../../models/genreViewModel.interface";

class QueryParams {
    takeCount?: number;
    genres?: Array<string>;
    year?: number;
    orderTypes?: Array<MovieOrderType>;
    pageNumber?: number;
}

@Component({
  selector: 'app-catalog-search',
  templateUrl: './catalog-search.component.html',
  styleUrls: ['./catalog-search.component.css']
})
export class CatalogSearchComponent implements OnInit {

    queryParams: QueryParams = {};

    currentPage: number = 1;

    movies!: IMovieCard[];

    genres!: GenreViewModel[];

    constructor(private activatedRoute: ActivatedRoute,
                private movieService: MovieService,
                private genreService: GenreService) { }

    ngOnInit(): void {

        this.getGenres();

        this.activatedRoute.queryParams.subscribe(params => {

            this.queryParams.takeCount = 16;

            if('genres' in params) {
                this.queryParams.genres = [ params['genres'] ];
            }
            if('year' in params) {
                this.queryParams.year = params['year'];
            }
            if('orderTypes' in params) {
                this.queryParams.orderTypes = [... params['orderTypes']].map(e => Number(e));
            }

            this.queryParams.pageNumber = this.currentPage;

            this.getMovies();
        });
    }

    private getMovies() {

        this.movieService.getMovies('api/movies', this.queryParams).subscribe({
            next: (data: MovieViewModel[]) => {
                this.movies = data.map((element) => {
                    return {
                        type: 'defaultPreview',
                        info: element
                    }
                });

                console.log(this.movies);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err)
            }
        });
    }

    private getGenres() {

        this.genreService.getGenres('api/genres').subscribe({
            next: (data: GenreViewModel[]) => {
                this.genres = data;
                console.log(this.genres);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err)
            }
        });
    }

}
