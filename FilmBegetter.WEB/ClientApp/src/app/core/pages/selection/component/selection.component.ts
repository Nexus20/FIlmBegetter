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
  public selectedFirst!: MovieViewModel | null;
  public selectedSecond!: MovieViewModel | null;
  public placeholderImage = DEFAULT_CARD;
  public selectionForm!: FormGroup;

  private destroy$: Subject<void> = new Subject();

  public selectionConfig = CSelectionPage;

  public bestOptions: IMovieCard[] = [
    {
      type: 'smallPreview',
      info: {
        id: '2',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        //movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'smallPreview',
      info: {
        id: '3',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        //movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'smallPreview',
      info: {
        id: '4',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        //movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'smallPreview',
      info: {
        id: '5',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        //movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'smallPreview',
      info: {
        id: '6',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        //movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'smallPreview',
      info: {
        id: '7',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        //movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'smallPreview',
      info: {
        id: '8',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        //movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'smallPreview',
      info: {
        id: '9',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        //movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'smallPreview',
      info: {
        id: '10',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        //movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
  ];

  public bestOptionsDefaultSize: IMovieCard[] = [
    {
      type: 'defaultPreview',
      info: {
        id: '2',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        // movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'defaultPreview',
      info: {
        id: '3',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        // movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'defaultPreview',
      info: {
        id: '4',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        // movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'defaultPreview',
      info: {
        id: '5',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        // movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'defaultPreview',
      info: {
        id: '6',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        // movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'defaultPreview',
      info: {
        id: '7',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        // movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'defaultPreview',
      info: {
        id: '8',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        // movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
    {
      type: 'defaultPreview',
      info: {
        id: '9',
        title: 'Black Widow',
        description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
        country: 'Ukraine',
        director: 'Horkun Dmytro',
        imagePath: '../../../../../assets/images/card-preview.png',
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
          rating: 2
        }],
        commonRating: 6.8,
        // movieCollections: ['New realizes', 'Best June'],
        genres: [],
        publicationDate: new Date()
      }
    },
  ];

  constructor(private movieService: MovieService, private fb: FormBuilder) { }

  public movies!: IMovieCard[];

  public getMovies = () => {
    this.movieService.getMovies("api/movies", { takeCount: 8 }).pipe(takeUntil(this.destroy$))
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

    this.selectionForm.valueChanges.pipe(
      takeUntil(this.destroy$),
      debounceTime(300),
      distinctUntilChanged(),
      switchMap(values => {

        let [firstSearchString, secondSearchString] = [values['firstSection'], values['secondSection']];

        return forkJoin(
          [firstSearchString ? this.movieService.getMovies("api/movies", { title: firstSearchString }) : of([]),
          secondSearchString ? this.movieService.getMovies("api/movies", { title: secondSearchString }) : of([])]
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
