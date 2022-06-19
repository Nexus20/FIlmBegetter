import { IComment } from './comment.interface';

export interface IMovie {
    id: string,
    title: string,
    description: string,
    country: string,
    director: string,
    publicationDate: Date,
    imagePath: string,
    // comments: IComment[],//uncomment in future
    comments: string[],
    //    raitings: IRaiting[],//uncomment in future
    raiting: number,
    // movieCollections: IMovieCollection[],//uncomment in future
    movieCollections: string[],
    // movieGenres: IGenre[],//uncomment in future
    movieGenres: string[],
}
