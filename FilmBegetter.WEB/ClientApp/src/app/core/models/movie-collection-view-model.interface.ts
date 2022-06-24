import {UserViewModel} from "./user-view-model.interface";
import {MovieViewModel} from "./movieViewModel.interface";

export interface MovieCollectionViewModel {

    name: string;
    authorId: string;
    author: UserViewModel;
    movies: MovieViewModel[];
}

