import { IUser } from './../../core/models/user.interface';

export interface IUserCard {
    type: 'user',
    info: IUser
}
