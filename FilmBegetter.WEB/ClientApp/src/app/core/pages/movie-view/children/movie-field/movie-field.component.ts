import { Component, Input, OnInit } from '@angular/core';
import { ImovieField } from '../../entity/movie-field.interface';

@Component({
  selector: 'app-movie-field',
  templateUrl: './movie-field.component.html',
  styleUrls: ['./movie-field.component.scss']
})
export class MovieFieldComponent implements OnInit {


  @Input() fieldConfig!: ImovieField;

  constructor() { }

  public ngOnInit(): void {
  }

  public transformTodate(value: any): Date {
    return new Date(value);
  }

  public transformToArray(value: any): string[] {
    return [...value];
  }

}
