import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MovieViewModel} from "../../../models/movieViewModel.interface";
import {HttpErrorResponse} from "@angular/common/http";
import {MovieService} from "../../../services/movie.service";
import {IMovieCard} from "../../../../shared/models/card.interface";
import {GenreService} from "../../../services/genre.service";
import {GenreViewModel} from "../../../models/genreViewModel.interface";
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {IInput} from "../../../../shared/models/input.interface";
import {IButton} from "../../../../shared/models/button.interface";
import {ICustomSelect} from "../../../../shared/models/custom-select.interface";
import {QueryParams} from "../../../models/query-params";


@Component({
  selector: 'app-catalog-search',
  templateUrl: './catalog-search.component.html',
  styleUrls: ['./catalog-search.component.scss']
})
export class CatalogSearchComponent implements OnInit {

    queryParams: QueryParams = {};

    currentPage: number = 1;

    movies!: IMovieCard[];

    genres!: GenreViewModel[];

    filterForm!: FormGroup;

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
    resetButtonConfig: IButton = {
        type: 'default',
        size: 'default',
        text: 'Reset filters',
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

    constructor(private activatedRoute: ActivatedRoute,
                private movieService: MovieService,
                private genreService: GenreService,
                private formBuilder: FormBuilder) { }

    ngOnInit(): void {

        this.initForm();

        this.getGenres();

        this.activatedRoute.queryParams.subscribe(params => {

            this.queryParams.takeCount = 16;

            if('genres' in params) {
                this.queryParams.genres = [ params['genres'] ];
            }
            if('year' in params) {
                this.queryParams.year = params['year'];
                this.filterForm.controls['year'].setValue(this.queryParams.year);
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

    sendForm(formValue: any) {
        this.currentPage = 1;
        this.queryParams.pageNumber = this.currentPage;
        this.queryParams.genres = formValue.genres;
        this.queryParams.title = formValue.title;
        this.queryParams.country = formValue.country;
        this.queryParams.director = formValue.director;
        this.queryParams.year = Number(formValue.year);

        if(formValue.order != null) {
            this.queryParams.orderTypes = [Number(formValue.order)];
        }

        this.getMovies();
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

    hasGenre(id: string) : boolean {
        return false;
    }

    loadMore() {
        this.currentPage++;
        this.queryParams.pageNumber = this.currentPage;

        console.log(this.queryParams);

        this.movieService.getMovies('api/movies', this.queryParams).subscribe({
            next: (data: MovieViewModel[]) => {

                for (let i = 0; i < data.length; i++) {
                    this.movies.push({type: 'defaultPreview', info: data[i]});
                }

                console.log(this.movies);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err)
            }
        });
    }

    reset() {
        this.queryParams = {};
        this.queryParams.pageNumber = this.currentPage = 1;
        this.getMovies();
    }
}
