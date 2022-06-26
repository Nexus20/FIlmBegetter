import { CommentViewModel } from './../../../core/models/commentViewModel.interface';
import { Component, Input, OnInit } from '@angular/core';
import {CommentService} from "../../../core/services/comment.service";
import {UpdateCommentRatingViewModel} from "../../../core/models/updateCommentRatingViewModel.interface";
import {GenreViewModel} from "../../../core/models/genreViewModel.interface";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {

  @Input() comment!: CommentViewModel

  constructor(private commentService: CommentService) { }

  ngOnInit(): void {
  }


  public updateRate(rate: number): void {
    // this.comment.rating = rate;// here only for change view. Delete after service implementation
    //here service for change rate

      const body: UpdateCommentRatingViewModel = {
          commentId: this.comment.id,
          rating: rate
      }

      this.commentService.rateComment(`api/comments/${this.comment.id}`, body).subscribe({
          next: (data: any) => {
              console.log(data);
              this.comment.rating += rate;
          },
          error: (err: HttpErrorResponse) => {
              console.log(err);
          }
      })
  }
}
