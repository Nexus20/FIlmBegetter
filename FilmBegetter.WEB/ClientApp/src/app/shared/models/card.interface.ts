import { MovieViewModel } from "../../core/models/movieViewModel.interface";

export interface IMovieCard {
  type: 'defaultPreview' | 'smallPreview' | 'adminView' | 'preloader',
  info: MovieViewModel
}
