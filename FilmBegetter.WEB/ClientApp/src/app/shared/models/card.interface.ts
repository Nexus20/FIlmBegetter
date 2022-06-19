import { IMovie } from './../../core/models/movie.interface';

export interface IMovieCard {
    type: 'defaultPreview' | 'smallPreview' | 'adminView',
    info: IMovie
}
