import { IMovie } from './../../core/models/movie.interface';
import { MovieViewModel } from "./movieViewModel.interface";

export interface IMovieCard {
    type: 'defaultPreview' | 'smallPreview' | 'adminView',
    info: MovieViewModel
}
