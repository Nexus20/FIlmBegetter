import { UserService } from './../../../services/user.service';
import { IPreloaderCard } from './../../../../shared/models/card-preloader.interface';
import { AuthenticationService } from './../../../../shared/services/authentication.service';
import { DEFAULT_CARD } from './../../../../shared/enums/placeholder-card.config';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserViewModel } from './../../../models/user-view-model.interface';
import { IMovieCard } from '../../../../shared/models/card.interface';
import { CSelectionPage } from '../selection.config';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { HttpErrorResponse } from "@angular/common/http";
import { MovieViewModel } from "../../../models/movieViewModel.interface";
import { MovieService } from "../../../services/movie.service";
import { debounceTime, distinctUntilChanged, forkJoin, of, Subject, switchMap, takeUntil, tap } from 'rxjs';
import { animate, style, transition, trigger } from '@angular/animations';
import { SelectedMoviesViewModel } from "../../../models/selectedMoviesViewModel.interface";
import {MovieOrderType} from "../../../../shared/enums/movieOrderType";


@Component({
  selector: 'app-selection',
  templateUrl: './selection.component.html',
  styleUrls: ['./selection.component.scss'],
  animations: [
    trigger('fade', [
      transition(':enter', [
        style({ opacity: 0 }), animate('300ms', style({ opacity: 1 }))]
      ),
      transition(':leave',
        [style({ opacity: 1 }), animate('300ms', style({ opacity: 0 }))]
      )
    ])
  ]
})
export class SelectionComponent implements OnInit, OnDestroy {

  public firstResults: MovieViewModel[] = [];
  public secondResults: MovieViewModel[] = [];
  public bestOptions!: IMovieCard[];
  public selectedFirst!: MovieViewModel | null;
  public selectedSecond!: MovieViewModel | null;
  public placeholderImage = DEFAULT_CARD;
  public selectionForm!: FormGroup;
  public isAuth!: boolean
  public selectionConfig = CSelectionPage;
  public isSearch!: boolean;
  public isDefaultUser!: boolean;

  private destroy$: Subject<void> = new Subject();

  constructor(
    private movieService: MovieService,
    private fb: FormBuilder,
    private authService: AuthenticationService,
    private userService: UserService) { }

  public movies: IMovieCard[] = [{
    type: 'preloader',
    info: {} as MovieViewModel
  },
  {
    type: 'preloader',
    info: {} as MovieViewModel
  },
  {
    type: 'preloader',
    info: {} as MovieViewModel
  },
  {
    type: 'preloader',
    info: {} as MovieViewModel
  },
  {
    type: 'preloader',
    info: {} as MovieViewModel
  },
  {
    type: 'preloader',
    info: {} as MovieViewModel
  },
  {
    type: 'preloader',
    info: {} as MovieViewModel
  },
  {
    type: 'preloader',
    info: {} as MovieViewModel
  },
  ];


  public onSubmit(): void {
    if (this.selectedFirst && this.selectedSecond) {

      if (!this.isAuth) {
        this.authService.openModal(true);
        return;
      }
      this.isSearch = true;

      this.userService.getCurrentUser("api/users/currentUser")
        .pipe(takeUntil(this.destroy$))
        .subscribe(user => {
          this.isDefaultUser = user.subscription.type === "Basic";
        });

      const selectedMoviesIds: SelectedMoviesViewModel = {
        firstMovieId: this.selectedFirst.id, secondMovieId: this.selectedSecond.id
      }
      this.movieService.getRecommendations("api/movies/recommend", selectedMoviesIds)
        .pipe(takeUntil(this.destroy$))
        .subscribe({
          next: (data: MovieViewModel[]) => {
            const resultMovies = data.map((element) => {
              return {
                type: 'smallPreview' as 'smallPreview',
                info: element
              }
            });
            this.bestOptions = resultMovies;
            this.isSearch = false;
          },
          error: (err: HttpErrorResponse) => {
            console.log(err);
          }
        });
    }
  }

  public getMovies = () => {
    this.movieService.getMovies("api/movies", { takeCount: 8, orderTypes: [MovieOrderType.RatingDesc] }).pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (data: MovieViewModel[]) => {
          this.movies = data.map(elem => { return { info: elem, type: "defaultPreview" } });
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
        }
      });
  }

  public ngOnInit(): void {
    this.getMovies();
    this.initForm();
    this.authService.authChanged.pipe(takeUntil(this.destroy$))
      .subscribe(authInfo => {
        this.isAuth = authInfo.isAuthenticated;
      })

    this.selectionForm.valueChanges.pipe(
      takeUntil(this.destroy$),
      debounceTime(300),
      distinctUntilChanged(),
      switchMap(values => {

        let [firstSearchString, secondSearchString] = [values['firstSection'], values['secondSection']];

        return forkJoin(
          [firstSearchString ? this.movieService.getMovies("api/movies", { title: firstSearchString, orderTypes: [MovieOrderType.RatingDesc] }) : of([]),
          secondSearchString ? this.movieService.getMovies("api/movies", { title: secondSearchString, orderTypes: [MovieOrderType.RatingDesc] }) : of([])]
        )
      })
    )
      .subscribe(resulstValues => {
        let [resultFirst, resultSecond] = resulstValues;

        if (this.isChanged(this.firstResults, resultFirst)) {
          this.firstResults = resultFirst;
          this.selectedFirst = null;
        }
        if (this.isChanged(this.secondResults, resultSecond)) {
          this.secondResults = resultSecond;
          this.selectedSecond = null;
        }
      });
  }

  private initForm(): void {
    this.selectionForm = this.fb.group({
      firstSection: this.fb.control(''),
      secondSection: this.fb.control(''),
    });
  }

  public onClickmovie(value: 'first' | 'second', movie: MovieViewModel): void {
    if (value === 'first') {
      this.selectedFirst = movie;
    }
    else {
      this.selectedSecond = movie;
    }
  }

  private isChanged(previous: any[], current: any[]): boolean {
    return JSON.stringify(previous) !== JSON.stringify(current);
  }

  public ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
