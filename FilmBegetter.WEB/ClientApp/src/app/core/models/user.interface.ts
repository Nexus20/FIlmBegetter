import {IComment} from './comment.interface';

export interface IUser {
    id: string,
    passwotd: string,
    email: string,
    // movieCollections: IMovieCollection[], //uncomment in future
    movieCollections: string[],
    friends: IUser[],
    comments: IComment[],
    // userRoles: IUserRole[],//uncomment in future
    userRoles: string[],
    // subscription: ISubscription, //uncomment in future
    subscription: 'Default' | 'Premium',
    isBanned: boolean,
    subscriptionId: string
    unBanTime?: Date,
    subscriptionUntil?: Date,
    name?: string,
    surname?: string,
}
