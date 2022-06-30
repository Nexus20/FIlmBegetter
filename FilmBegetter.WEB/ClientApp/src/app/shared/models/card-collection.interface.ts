import {MovieCollectionViewModel} from "../../core/models/movie-collection-view-model.interface";

export interface ICollectionCard {
    type: 'collection'
    info: MovieCollectionViewModel
}
