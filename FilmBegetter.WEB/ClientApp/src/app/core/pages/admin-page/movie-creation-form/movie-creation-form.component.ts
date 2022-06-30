import { Component, OnInit } from '@angular/core';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import { GenreViewModel } from "../../../models/genreViewModel.interface";
import { GenreService } from "../../../services/genre.service";
import { HttpErrorResponse } from "@angular/common/http";
import { MovieService } from "../../../services/movie.service";
import {Router} from "@angular/router";
import {IInput} from "../../../../shared/models/input.interface";
import {IButton} from "../../../../shared/models/button.interface";
import {ISideMenu} from "../../../../shared/components/side-menu/side-menu.interface";

@Component({
  selector: 'app-movie-creation-form',
  templateUrl: './movie-creation-form.component.html',
  styleUrls: ['./movie-creation-form.component.scss']
})
export class MovieCreationFormComponent implements OnInit {

    public routes: ISideMenu[] = [
        {
            icon: 'video-play',
            route: 'admin/movies',
            label: 'Movies'
        },
        {
            icon: 'video-play',
            route: 'admin/movies/new',
            label: 'New movie'
        },
        {
            icon: 'person',
            route: 'admin/users',
            label: 'Users'
        },
        {
            icon: 'statistics',
            route: '',
            label: 'Statistics'
        },

    ];

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

    movieForm!: FormGroup;

    genres!: GenreViewModel[];

    file: File | null = null;

    constructor(private genreService: GenreService, private movieService: MovieService, private formBuilder: FormBuilder, private router: Router) { }

    ngOnInit(): void {

        this.movieForm = new FormGroup( {
            title: new FormControl('', [Validators.required]),
            description: new FormControl('', [Validators.required]),
            country: new FormControl('', [Validators.required]),
            director:  new FormControl('', [Validators.required]),
            publicationDate:  new FormControl('', [Validators.required]),
            // genres: new FormControl('', [Validators.required]),
            genres: this.formBuilder.array([], [Validators.required]),

            image: new FormControl()
        });

        this.getGenres();
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
        formData.append('title', this.movieForm.get('title')?.value);
        formData.append('country', this.movieForm.get('country')?.value);
        formData.append('description', this.movieForm.get('description')?.value);
        formData.append('director', this.movieForm.get('director')?.value);
        formData.append('publicationDate', this.movieForm.get('publicationDate')?.value);
        console.log(this.movieForm.get('genres')?.value);

        formData.append('genres', this.movieForm.get('genres')?.value);

        if(this.file != null) {
            formData.append('file', this.file, this.file.name);
        }

        this.movieService.create("api/movies", formData).subscribe({
            next: (data: any) => {
                console.log(data);
                this.router.navigate(['/admin/movies']);
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
}
