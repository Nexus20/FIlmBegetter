import {Component, OnInit} from '@angular/core';
import {MovieService} from "../../../services/movie.service";
import {HttpErrorResponse} from "@angular/common/http";
import {MovieViewModel} from "../../../models/movieViewModel.interface";
import {IMovieCard} from "../../../../shared/models/card.interface";
import {ISideMenu} from "../../../../shared/components/side-menu/side-menu.interface";
import {routes} from '../admin-routes.config';
import {GenreViewModel} from "../../../models/genreViewModel.interface";
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {GenreService} from "../../../services/genre.service";
import {IInput} from "../../../../shared/models/input.interface";
import {IButton} from "../../../../shared/models/button.interface";
import {ICustomSelect} from "../../../../shared/models/custom-select.interface";

@Component({
    selector: 'app-movies',
    templateUrl: './movies.component.html',
    styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {

    public routes: ISideMenu[] = routes;

    movies!: IMovieCard[];

    genres!: GenreViewModel[];

    filterForm!: FormGroup;

    constructor(private movieService: MovieService,
                private genreService: GenreService,
                private formBuilder: FormBuilder) {}

    ngOnInit(): void {

        this.initForm();

        this.getGenres();

        this.getMovies();
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

    private initForm() {
        this.filterForm = new FormGroup({
            title: new FormControl(""),
            country: new FormControl(""),
            director: new FormControl(""),
            year: new FormControl("", [Validators.min(0)]),
            genres: this.formBuilder.array([]),
            order: new FormControl()
        });
    }

    private getMovies = () => {
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

    sendForm(formValue: any) {
        console.log(formValue);
    }

    loadMore() {

    }

    onGenreSelect(event: any) {

        const checkboxes: FormArray = this.filterForm.get('genres') as FormArray;

        console.log(checkboxes);

        if (event.target.checked) {
            checkboxes.push(new FormControl(event.target.value));
        } else {
            let i: number = 0;
            checkboxes.controls.forEach((item: any) => {
                if (item.value == event.target.value) {
                    checkboxes.removeAt(i);
                    return;
                }
                i++;
            });
        }
    }

    titleInputConfig: IInput = {
        isdisabled: false,
        placeholder: "Title",
        type: "default",
    };
    countryInputConfig:  IInput = {
        isdisabled: false,
        placeholder: "Country",
        type: "default",
    };
    directorInputConfig:  IInput = {
        isdisabled: false,
        placeholder: "Director",
        type: "default",
    };
    yearInputConfig:  IInput = {
        isdisabled: false,
        placeholder: "Year",
        type: "default",
    };
    submitButtonConfig: IButton = {
        type: 'success',
        size: 'default',
        text: 'Apply filters',
        disabled: false
    };
    loadMoreButtonConfig: IButton = {
        type: 'default',
        size: 'default',
        text: 'Load more',
        disabled: false
    };
    orderBySelectConfig: ICustomSelect = {
        title: 'Order by',
        elements: [
            { text: 'Rating: worst first', value: "0" },
            { text: 'Rating: best first', value: "1" },
        ]
    }
}
