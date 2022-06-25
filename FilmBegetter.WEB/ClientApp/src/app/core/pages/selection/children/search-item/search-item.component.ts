import { MovieViewModel } from './../../../../models/movieViewModel.interface';
import { MovieViewComponent } from './../../../movie-view/component/movie-view/movie-view.component';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-search-item',
  templateUrl: './search-item.component.html',
  styleUrls: ['./search-item.component.scss']
})
export class SearchItemComponent implements OnInit {

  @Input() searchItem!: MovieViewModel;

  constructor() { }

  ngOnInit(): void {
  }

}
