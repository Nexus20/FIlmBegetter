import { IMovieCard } from './../../models/card.interface';
import { Component, Input, OnInit } from '@angular/core';
import {MovieViewModel} from "../../models/movieViewModel.interface";

@Component({
    selector: 'app-collection',
    templateUrl: './collection.component.html',
    styleUrls: ['./collection.component.scss']
})
export class CollectionComponent implements OnInit {

    @Input() direction: 'default' | 'horizontal' = 'default';
    @Input() label!: string;
    @Input() movies!: IMovieCard[];

    constructor() { }

    ngOnInit(): void {
    }

    public getTotalMoviesNumber(): number {

        if(this.movies == undefined) {
            return 0;
        }

        return this.movies.length;
    }

}
