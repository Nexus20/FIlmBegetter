import { Subject } from 'rxjs';
import {FormBuilder, FormGroup, ɵFormGroupValue, ɵTypedOrUntyped} from '@angular/forms';
import { Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { IInput } from './../../../../../shared/models/input.interface';
import { MovieViewModel } from './../../../../models/movieViewModel.interface';
import { IButton } from './../../../../../shared/models/button.interface';
import { ImovieField } from './../../entity/movie-field.interface';
import { EMovieFieldType } from '../../entity/movie-field.enum';
import { CommentService } from "../../../../services/comment.service";
import { HttpErrorResponse } from "@angular/common/http";
import { CommentToCreateViewModel } from "../../../../models/commentToCreateViewModel.interface";
import { CommentViewModel } from "../../../../models/commentViewModel.interface";

@Component({
  selector: 'app-movie-view',
  templateUrl: './movie-view.component.html',
  styleUrls: ['./movie-view.component.scss']
})
export class MovieViewComponent implements OnInit {

  public configuration!: { type: ImovieField, date: ImovieField, duration: ImovieField, genres: ImovieField };
  public addCommentForm!: FormGroup;
  public movie!: MovieViewModel;

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


  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private commentService: CommentService) {
  }

  public ngOnInit(): void {
    this.route.data.subscribe(response => {
      this.movie = response.movie;
    })

    this.configuration = this.generateConfig();
    this.initForm();

  }


  public generateConfig(): { type: ImovieField, date: ImovieField, duration: ImovieField, genres: ImovieField } {
    const { publicationDate: date, genres } = this.movie;

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

  public onSubmit(formValue: any): void {

    if (this.addCommentForm.valid) {

        const formValues = {...formValue};

        const comment: CommentToCreateViewModel = {
            body: formValues.comment,
            movieId: this.movie.id
        }

        this.commentService.create("api/comments", comment).subscribe({
            next: (data: CommentViewModel) => {
                console.log(data);
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
                console.log(err.message);
                console.log(err.error);
            }
        });

        this.addCommentForm.reset();
    }
  }

  private initForm(): void {
    this.addCommentForm = this.formBuilder.group({
      comment: this.formBuilder.control('', [Validators.required, Validators.minLength(10)])
    });
  }

}
