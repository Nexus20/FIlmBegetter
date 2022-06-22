import {MovieViewModel} from "../../core/models/movieViewModel.interface";

export interface IMovieCard {
    type: 'defaultPreview' | 'smallPreview' | 'adminView',
    info: MovieViewModel
}
