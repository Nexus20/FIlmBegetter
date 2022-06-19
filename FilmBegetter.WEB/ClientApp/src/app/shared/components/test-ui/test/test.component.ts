import { IUserCard } from './../../../models/card-user.interface';
import { IStatistics } from './../../../models/card-statistics.interface copy';
import { IMovieCard } from './../../../models/card.interface';
import { IInput } from './../../../models/input.interface';
import { IButton } from './../../../models/button.interface';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

    constructor() { }

    ngOnInit(): void {
    }

    //buttons
    public defaultButton: IButton = {
        type: 'default',
        size: 'default',
        text: 'Default button',
        disabled: false,
    }

    public dangerButton: IButton = {
        type: 'danger',
        size: 'default',
        text: 'Danger button',
        disabled: false,
    }

    public successButton: IButton = {
        type: 'success',
        size: 'default',
        text: 'Success button',
        disabled: false,
    }

    public smallButton: IButton = {
        type: 'default',
        size: 'small',
        text: 'Small button',
        disabled: false,
    }

    public disabledButton: IButton = {
        type: 'default',
        size: 'small',
        text: 'Disabled button',
        disabled: true,
    }

    public iconButton: IButton = {
        type: 'default',
        size: 'small',
        text: 'Logo button',
        disabled: false,
        icon: 'logo'
    }

    public linkButton: IButton = {
        type: 'default',
        size: 'small',
        text: 'Link button',
        disabled: false,
        href: '/'
    }

    public unactive: IButton = {
        type: 'default',
        size: 'small',
        text: 'Unactive button',
        disabled: false,
        icon: 'logo',
        unactive: true
    }


    //inputs

    public defaultInput: IInput = {
        type: 'default',
        placeholder: 'Your name',
        isdisabled: false,
    }

    public disabledInput: IInput = {
        type: 'default',
        placeholder: 'Disabled input :(',
        isdisabled: true,
    }

    public defaultIconInput: IInput = {
        type: 'default',
        placeholder: 'Your comment...',
        isdisabled: false,
        icon: 'logo'
    }

    public errorIconInput: IInput = {
        type: 'default',
        placeholder: 'Error input...',
        isdisabled: false,
        icon: 'lock',
        error: 'Field is required'
    }

    public textareaInput: IInput = {
        type: 'textarea',
        placeholder: 'Your comment...',
        isdisabled: false,
    }

    public textareaIconInput: IInput = {
        type: 'textarea',
        placeholder: 'Your comment...',
        isdisabled: false,
        icon: 'logo'
    }

    public textareaErrorIconInput: IInput = {
        type: 'textarea',
        placeholder: 'Error textarea ..',
        isdisabled: false,
        icon: 'logo',
        error: 'Your message contains forbidden words'
    }

    //cards
    public movieCardDefault: IMovieCard = {
        type: 'defaultPreview',
        info: {
            id: '1',
            title: 'Black Widow',
            description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
            country: 'Ukraine',
            director: 'Horkun Dmytro',
            imagePath: '../../../../../assets/images/card-preview.png',
            comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
            raiting: 6.8,
            movieCollections: ['New realizes', 'Best June'],
            movieGenres: ['Actions', 'Drama'],
            publicationDate: new Date()
        }
    }

    public movieCardSmall: IMovieCard = {
        type: 'smallPreview',
        info: {
            id: '2',
            title: 'Black Widow',
            description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
            country: 'Ukraine',
            director: 'Horkun Dmytro',
            imagePath: '../../../../../assets/images/card-preview.png',
            comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
            raiting: 6.8,
            movieCollections: ['New realizes', 'Best June'],
            movieGenres: ['Actions', 'Drama'],
            publicationDate: new Date()
        }
    }

    public movieCardAdmin: IMovieCard = {
        type: 'adminView',
        info: {
            id: '3',
            title: 'Black Widow',
            description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
            country: 'Ukraine',
            director: 'Horkun Dmytro',
            imagePath: '../../../../../assets/images/card-preview.png',
            comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
            raiting: 6.8,
            movieCollections: ['New realizes', 'Best June'],
            movieGenres: ['Actions', 'Drama'],
            publicationDate: new Date()
        }
    }

    //cards:: statistics card
    public statisticsCard: IStatistics = {
        type: 'statistics',
        title: 'Movies',
        value: 93
    }

    //cards:: user card for admin panel
    public userCard: IUserCard = {
        type: 'user',
        info: {
            id: '1',
            passwotd: 'qwe',
            email: 'qwe@wqe',
            movieCollections: [],
            friends: [],
            comments: [],
            userRoles: [],
            subscription: 'Premium',
            isBanned: false,
            subscriptionId: '1',
            subscriptionUntil: new Date(),
            name: 'John',
            surname: 'Doe',
        }
    }
}
