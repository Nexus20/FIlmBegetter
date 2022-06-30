import {CommentViewModel} from "./commentViewModel.interface";
import {SubscriptionViewModel} from "./subscription-view-model.interface";
import {RoleViewModel} from "./role-view-model.interface";
import {RatingViewModel} from "./rating-view-model.interface";
import {MovieCollectionViewModel} from "./movie-collection-view-model.interface";
import {FriendRequestViewModel} from "./friendRequestViewModel.interface";

export interface UserViewModel {

    id: string;
    name: string;
    surname: string;
    subscriptionExpirationDare?: Date;
    username: string;
    email: string;
    isBanned: boolean;
    unbanDate?: Date;
    subscription: SubscriptionViewModel;
    roles: RoleViewModel[];
    comments: CommentViewModel[];
    friends: UserViewModel[];
    ratings: RatingViewModel[];
    movieCollections: MovieCollectionViewModel[];
    sentFriendRequests: FriendRequestViewModel[];
    receivedFriendRequests: FriendRequestViewModel[];
}

