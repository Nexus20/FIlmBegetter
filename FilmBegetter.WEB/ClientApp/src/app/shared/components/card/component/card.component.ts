import { IUserCard } from './../../../models/card-user.interface';
import { IStatistics } from './../../../models/card-statistics.interface copy';
import { IMovieCard } from './../../../models/card.interface';
import { Component, Input, OnInit } from '@angular/core';
import {MovieViewModel} from "../../../models/movieViewModel.interface";

@Component({
    selector: 'app-card',
    templateUrl: './card.component.html',
    styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

    public cardParameters!: IMovieCard | IStatistics | IUserCard;

    @Input() set movieCardParameters(value: IMovieCard | IStatistics | IUserCard) {
        this.cardParameters = value;
    }

    constructor() { }

    ngOnInit(): void {
    }

}
