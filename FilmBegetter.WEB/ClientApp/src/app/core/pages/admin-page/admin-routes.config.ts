import {ISideMenu} from "../../../shared/components/side-menu/side-menu.interface";

export const routes: ISideMenu[] = [
    {
        icon: 'video-play',
        route: 'admin/movies',
        label: 'Movies'
    },
    {
        icon: 'video-play',
        route: 'admin/movies/new',
        label: 'New movie'
    },
    {
        icon: 'person',
        route: 'admin/users',
        label: 'Users'
    },
    {
        icon: 'statistics',
        route: '',
        label: 'Statistics'
    },
];
