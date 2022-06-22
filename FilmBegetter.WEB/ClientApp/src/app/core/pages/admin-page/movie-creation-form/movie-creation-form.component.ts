import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { GenreViewModel } from "../../../models/genreViewModel.interface";
import { GenreService } from "../../../services/genre.service";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: 'app-movie-creation-form',
  templateUrl: './movie-creation-form.component.html',
  styleUrls: ['./movie-creation-form.component.scss']
})
export class MovieCreationFormComponent implements OnInit {

    movieForm!: FormGroup;

    genres!: GenreViewModel[];

    constructor(private genreService: GenreService) { }

    ngOnInit(): void {

        this.movieForm = new FormGroup( {
            title: new FormControl('', [Validators.required]),
            description: new FormControl('', [Validators.required]),
            country: new FormControl('', [Validators.required]),
            director:  new FormControl('', [Validators.required]),
            publicationDate:  new FormControl('', [Validators.required]),
            genres: new FormControl('', [Validators.required]),
            image: new FormControl()
        });

        this.getGenres();
    }

    public getGenres = () => {
        this.genreService.getGenres("api/genres").subscribe({
            next: (data: GenreViewModel[]) => {
                console.log(data);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }
}
