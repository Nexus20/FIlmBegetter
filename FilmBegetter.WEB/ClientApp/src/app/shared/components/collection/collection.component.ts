import { IMovieCard } from './../../models/card.interface';
import { Component, Input, OnInit } from '@angular/core';

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
        return this.movies.length;
    }

}
