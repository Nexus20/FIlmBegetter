import { IMovieCard } from '../../../../shared/models/card.interface';
import { CSelectionPage } from '../selection.config';
import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from "@angular/common/http";
import { MovieViewModel } from "../../../models/movieViewModel.interface";
import { MovieService } from "../../../services/movie.service";


@Component({
    selector: 'app-selection',
    templateUrl: './selection.component.html',
    styleUrls: ['./selection.component.scss']
})
export class SelectionComponent implements OnInit {

    public selectionConfig = CSelectionPage;

    public bestOptions: IMovieCard[] = [
        {
            type: 'smallPreview',
            info: {
                id: '2',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                //movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'smallPreview',
            info: {
                id: '3',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                //movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'smallPreview',
            info: {
                id: '4',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                //movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'smallPreview',
            info: {
                id: '5',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                //movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'smallPreview',
            info: {
                id: '6',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                //movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'smallPreview',
            info: {
                id: '7',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                //movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'smallPreview',
            info: {
                id: '8',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                //movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'smallPreview',
            info: {
                id: '9',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                //movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'smallPreview',
            info: {
                id: '10',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                //movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
    ];

    public bestOptionsDefaultSize: IMovieCard[] = [
        {
            type: 'defaultPreview',
            info: {
                id: '2',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                // movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'defaultPreview',
            info: {
                id: '3',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                // movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'defaultPreview',
            info: {
                id: '4',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                // movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'defaultPreview',
            info: {
                id: '5',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                // movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'defaultPreview',
            info: {
                id: '6',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                // movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'defaultPreview',
            info: {
                id: '7',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                // movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'defaultPreview',
            info: {
                id: '8',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                // movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
        {
            type: 'defaultPreview',
            info: {
                id: '9',
                title: 'Black Widow',
                description: `Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem voluptates dolorem temporibus optio tempore, voluptate nesciunt blanditiis placeat maiores aut.`,
                country: 'Ukraine',
                director: 'Horkun Dmytro',
                imagePath: '../../../../../assets/images/card-preview.png',
                comments: [`Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis nulla, fuga quas laborum numquam illum.`, 'Lorem ipsum dolor sit amet'],
                commonRating: 6.8,
                // movieCollections: ['New realizes', 'Best June'],
                genres: [],
                publicationDate: new Date()
            }
        },
    ];

    constructor(private movieService: MovieService) { }

    public movies!: IMovieCard[];

    public getMovies = () => {
        this.movieService.getMovies("api/movies").subscribe({
            next: (data: {$id: string, $values: MovieViewModel[]}) => {

                this.movies = new Array<IMovieCard>();

                for (let i = 0; i < data.$values.length; i++) {

                    this.movies.push(<IMovieCard>{info: data.$values[i], type: "defaultPreview"})
                }
            },
            error: (err: HttpErrorResponse) => {
                console.log(err);
            }
        });
    }

    ngOnInit(): void {
        this.getMovies();
    }

}
