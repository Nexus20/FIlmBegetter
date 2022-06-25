import {IMovie} from './movie.interface';
import {IUser} from './user.interface';

export interface IComment {
    autorId: string,
    author: IUser,
    movieId: string,
    movie: IMovie,
    parentComment: IComment,
    // commentType: IType, //uncomment in future
    commentType: string,
    creationDate: Date,
    body: string
    parentCommentId?: string
}

