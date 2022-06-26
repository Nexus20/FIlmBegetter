import { MovieViewModel } from './movieViewModel.interface';
import { UserViewModel } from './user-view-model.interface';

export interface CommentViewModel {
    id: string;
  authorId: string,
  movieId: string,
  movie: MovieViewModel,
  author: UserViewModel,
  creationDate: Date,
  body: string,
  rating: number
}
