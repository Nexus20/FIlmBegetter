import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import { MovieService } from "../../../services/movie.service";
import { MovieViewModel } from "../../../models/movieViewModel.interface";
import { HttpErrorResponse } from "@angular/common/http";
import { GenreViewModel } from "../../../models/genreViewModel.interface";
import { GenreService } from "../../../services/genre.service";
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import {IInput} from "../../../../shared/models/input.interface";
import {IButton} from "../../../../shared/models/button.interface";
import {ISideMenu} from "../../../../shared/components/side-menu/side-menu.interface";
import { routes } from '../admin-routes.config';

@Component({
  selector: 'app-movie-updating-form',
  templateUrl: './movie-updating-form.component.html',
  styleUrls: ['./movie-updating-form.component.scss']
})
export class MovieUpdatingFormComponent implements OnInit {

    public routes: ISideMenu[] = routes;

    private movieId!: string;

    movie!: MovieViewModel;

    genres!: GenreViewModel[];

    movieForm!: FormGroup;

    file: File | null = null;

    constructor(private route: ActivatedRoute,
                private movieService: MovieService,
                private genreService: GenreService,
                private formBuilder: FormBuilder,
                private router: Router) {

        this.movieForm = new FormGroup( {
            id: new FormControl('', [Validators.required]),
            title: new FormControl('', [Validators.required]),
            description: new FormControl('', [Validators.required]),
            country: new FormControl('', [Validators.required]),
            director:  new FormControl('', [Validators.required]),
            publicationDate:  new FormControl('', [Validators.required]),
            genres: this.formBuilder.array([], [Validators.required]),
            imagePath: new FormControl(''),
            image: new FormControl()
        });
    }

    ngOnInit(): void {

        this.route.params.subscribe(params => {
          this.movieId = params.id;

          console.log(this.movieId);

          this.getMovie();
          this.getGenres();

        });
    }

    public getMovie = () => {
        this.movieService.getMovie(`api/movies/${this.movieId}`).subscribe({
            next: (data: MovieViewModel) => {

                this.movie = data;

                this.movieForm.controls['id'].setValue(this.movie.id);
                this.movieForm.controls['title'].setValue(this.movie.title);
                this.movieForm.controls['description'].setValue(this.movie.description);
                this.movieForm.controls['country'].setValue(this.movie.country);
                this.movieForm.controls['director'].setValue(this.movie.director);
                this.movieForm.controls['publicationDate'].setValue(this.movie.publicationDate.toString().split('T')[0]);
                this.movieForm.controls['imagePath'].setValue(this.movie.imagePath);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

    public getGenres = () => {
        this.genreService.getGenres("api/genres").subscribe({
            next: (data: GenreViewModel[]) => {
                console.log(data);
                this.genres = data;
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

    sendForm() {

        const formData = new FormData();
        formData.append('id', this.movieForm.get('id')?.value);
        formData.append('title', this.movieForm.get('title')?.value);
        formData.append('country', this.movieForm.get('country')?.value);
        formData.append('description', this.movieForm.get('description')?.value);
        formData.append('director', this.movieForm.get('director')?.value);
        formData.append('publicationDate', this.movieForm.get('publicationDate')?.value);
        formData.append('imagePath', this.movieForm.get('imagePath')?.value);
        formData.append('genres', this.movieForm.get('genres')?.value);

        if(this.file != null) {
            formData.append('file', this.file, this.file.name);
        }

        this.movieService.update(`api/movies/${this.movieId}`, formData).subscribe({
            next: (data: any) => {
                console.log(data);
                this.router.navigate([`/admin/movies/${this.movieId}/update`]);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        })
    }

    uploadFile(files: FileList | null) {
        console.log(files);

        if(files != null && files.length > 0) {
            this.file = files[0];

            console.log(this.file);
        }
    }

    onGenreSelect(event: any) {

        const checkboxes: FormArray = this.movieForm.get('genres') as FormArray;

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
        return this.movie.genres.some(v => v.id == id);
    }

    titleInputConfig: IInput = {
        isdisabled: false,
        placeholder: "Title",
        type: "default",
    };
    descriptionInputConfig: IInput = {
        isdisabled: false,
        placeholder: "Description",
        type: "textarea",
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
    publicationDateInputConfig:  IInput = {
        isdisabled: false,
        placeholder: "",
        type: "default",
    };
    imageInputConfig:  IInput = {
        isdisabled: false,
        placeholder: "",
        type: "default",
    };
    submitButtonConfig: IButton = {
        type: 'success',
        size: 'default',
        text: 'Add new movie',
        disabled: false
    };
}
