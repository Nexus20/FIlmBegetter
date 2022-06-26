import { BehaviorSubject, map, Observable, take } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from "../../shared/services/environment-url.service";
import { CommentToCreateViewModel } from "../models/commentToCreateViewModel.interface";
import { CommentViewModel } from "../models/commentViewModel.interface";
import {UpdateCommentRatingViewModel} from "../models/updateCommentRatingViewModel.interface";

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  private _comments: BehaviorSubject<CommentViewModel[]> = new BehaviorSubject<CommentViewModel[]>([]);
  public comments$: Observable<CommentViewModel[]> = this._comments.asObservable();

  public setComments(comments: CommentViewModel[]) {
    this._comments.next([...comments]);
  }

  public addComment(route: string, comment: CommentToCreateViewModel) {
    return this.http.post<CommentViewModel>(this.createCompleteRoute(route, this.envUrl.urlAddress), comment)
      .pipe(take(1))
      .subscribe(comment => {
        this._comments.next([...this._comments.getValue(), comment])
      });
  }

  public rateComment(route: string, body: UpdateCommentRatingViewModel) {
      return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
