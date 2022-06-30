import { IUser } from './../../core/models/user.interface';
import { UserViewModel } from "../../core/models/user-view-model.interface";

export interface IUserCard {
    type: 'user',
    info: UserViewModel
}
