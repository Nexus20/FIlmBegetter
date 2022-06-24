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


  public updateRate(rate: number): void {
    this.comment.rate = rate;// here only for change view. Delete after service implementation
    //here service for change rate
  }
}
