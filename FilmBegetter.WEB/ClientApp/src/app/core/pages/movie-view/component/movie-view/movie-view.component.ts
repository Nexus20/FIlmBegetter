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
  public btnConfig: IButton = {
    type: 'default',
    size: 'default',
    text: 'See later',
    disabled: false
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
      comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
      commonRating: 6.8,
      //movieCollections: ['New realizes', 'Best June'],
      genres: [],
      publicationDate: new Date()
    }
  };


  constructor(
    private route: ActivatedRoute,
    private router: Router) {
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
        value: ['Adventure', 'Action']
      }
    }
  }

  public ngOnInit(): void {
    this.configuration = this.generateConfig();
  }

}
