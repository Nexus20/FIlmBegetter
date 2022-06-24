import { Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IInput } from './../../../../../shared/models/input.interface';
import { MovieViewModel } from './../../../../models/movieViewModel.interface';
import { UserViewModel } from './../../../../models/user-view-model.interface';
import { IButton } from './../../../../../shared/models/button.interface';
import { ImovieField } from './../../entity/movie-field.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { IMovieCard } from './../../../../../shared/models/card.interface';
import { Component, Input, OnInit } from '@angular/core';
import { EMovieFieldType } from '../../entity/movie-field.enum';

@Component({
  selector: 'app-movie-view',
  templateUrl: './movie-view.component.html',
  styleUrls: ['./movie-view.component.scss']
})
export class MovieViewComponent implements OnInit {

  public configuration!: { type: ImovieField, date: ImovieField, duration: ImovieField, genres: ImovieField };
  public addCommentForm!: FormGroup;

  public btnConfig: IButton = {
    type: 'default',
    size: 'default',
    text: 'See later',
    disabled: false
  }

  public addCommentButton: IButton = {
    type: 'default',
    size: 'default',
    text: 'Comment',
    disabled: false
  }

  public addCommentinput: IInput = {
    type: 'textarea',
    placeholder: 'Start typing...',
    isdisabled: false,
    icon: 'logo'
  }

  @Input() movie: IMovieCard = {
    type: 'smallPreview',
    info: {
      id: '2',
      title: 'Black Widow',
      description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
      country: 'Ukraine',
      director: 'Horkun Dmytro',
      imagePath: '../../../../../assets/images/movie-background.png',
      comments: [{
        authorId: '1',
        movieId: '2',
        movie: {} as MovieViewModel,// bad practice, but only for test
        author: {
          name: "Joe",
          surname: "Dou"
        } as UserViewModel,// bad practice, but only for test
        creationDate: new Date(),
        body: 'Cool movie! The actress is extremely beautiful. Spent a great hour and a half and the mood is on the rise!',
        rate: 2
      }],
      commonRating: 6.8,
      //movieCollections: ['New realizes', 'Best June'],
      genres: [],
      publicationDate: new Date()
    }
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder) {
  }

  public generateConfig(): { type: ImovieField, date: ImovieField, duration: ImovieField, genres: ImovieField } {
    const { publicationDate: date, genres } = this.movie.info;

    return {
      type: {
        label: 'Type',
        type: EMovieFieldType.default,
        value: 'Movie'
      },
      date: {
        label: 'Release Date',
        type: EMovieFieldType.date,
        value: date
      },
      duration: {
        label: 'Run time',
        type: EMovieFieldType.duration,
        value: 180
      },
      genres: {
        label: 'Genres',
        type: EMovieFieldType.genres,
        value: ['Adventure', 'Action'] //TODO: create a function for retrive genres
      }
    }
  }

  public ngOnInit(): void {
    this.configuration = this.generateConfig();
    this.initForm();
  }

  public onSubmit(): void {
    if (this.addCommentForm.valid) {
      this.addCommentForm.reset();
    }
  }

  private initForm(): void {
    this.addCommentForm = this.formBuilder.group({
      comment: this.formBuilder.control('', [Validators.required, Validators.minLength(10)])
    });
  }

}
