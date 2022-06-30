import {ISideMenu} from "../../../shared/components/side-menu/side-menu.interface";

export const routes: ISideMenu[] =  [
    {
        icon: 'edit',
        route: 'profile/edit',
        label: 'Edit'
    },
    {
        icon: 'logo',
        route: 'profile/subscriptions',
        label: 'Subscription'
    },
    {
        icon: 'person',
        route: 'profile/friends',
        label: 'Friends'
    },
    {
        icon: 'star',
        route: 'profile/collections',
        label: 'Collections'
    }
];
