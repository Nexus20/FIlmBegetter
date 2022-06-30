import {GenreViewModel} from "./genreViewModel.interface";
import {CommentViewModel} from "./commentViewModel.interface";


export interface MovieViewModel {

    id: string;
    title: string;
    description: string;
    country: string;
    director: string;
    publicationDate: Date;
    genres: GenreViewModel[];
    imagePath: string;
    commonRating: number;
    comments: CommentViewModel[];
}
