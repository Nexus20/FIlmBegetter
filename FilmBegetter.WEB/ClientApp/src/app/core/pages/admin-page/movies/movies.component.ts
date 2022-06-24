import { Component, OnInit } from '@angular/core';
import { MovieService } from "../../../services/movie.service";
import { HttpErrorResponse } from "@angular/common/http";
import { MovieViewModel } from "../../../models/movieViewModel.interface";
import { IMovieCard } from "../../../../shared/models/card.interface";

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {

    movies!: IMovieCard[];

    constructor(private movieService: MovieService) { }

    public getMovies = () => {
        this.movieService.getMovies("api/movies").subscribe({
            next: (data: MovieViewModel[]) => {
                console.log(data);

                this.movies = new Array<IMovieCard>();

                for (let i = 0; i < data.length; i++) {

                    this.movies.push({
                        type: 'adminView',
                        info: data[i]
                    });
                }

                console.log(this.movies);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

  ngOnInit(): void {
      this.getMovies();
  }

}
