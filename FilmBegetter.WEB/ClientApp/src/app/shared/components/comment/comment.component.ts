import { CommentViewModel } from './../../../core/models/commentViewModel.interface';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {

  @Input() comment!: CommentViewModel

  constructor() { }

  ngOnInit(): void {
  }


  public updateRate(id: string, rate: number): void {
    this.comment.rating = rate;// here only for change view. Delete after service implementation
    //here service for change rate
  }
}
