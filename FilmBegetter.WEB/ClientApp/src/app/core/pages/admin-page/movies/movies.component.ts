import { Component, OnInit } from '@angular/core';
import { MovieService } from "../../../services/movie.service";
import { HttpErrorResponse } from "@angular/common/http";
import { MovieViewModel } from "../../../models/movieViewModel.interface";

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {

  constructor(private movieService: MovieService) { }

    public getMovies = () => {
        this.movieService.getMovies("api/movies").subscribe({
            next: (data: {$id: string, $values: MovieViewModel[]}) => {
                console.log(data);
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
