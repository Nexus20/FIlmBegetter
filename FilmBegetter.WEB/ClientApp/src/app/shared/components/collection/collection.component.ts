import { IMovieCard } from './../../models/card.interface';
import { Component, Input, OnInit } from '@angular/core';
import { IUserCard } from "../../models/card-user.interface";

@Component({
  selector: 'app-collection',
  templateUrl: './collection.component.html',
  styleUrls: ['./collection.component.scss']
})
export class CollectionComponent implements OnInit {

  @Input() direction: 'default' | 'horizontal' = 'default';
  @Input() label!: string;
  @Input() movies!: IMovieCard[];
  @Input() users!: IUserCard[];
  @Input() showBlock!: boolean;
  @Input() seeAll!: { router: string[], queryParams: object }

  constructor() { }

  ngOnInit(): void {
  }

  public getTotalMoviesNumber(): number {

    if (this.movies == undefined) {
      return 0;
    }

    return this.movies.length;
  }

}
