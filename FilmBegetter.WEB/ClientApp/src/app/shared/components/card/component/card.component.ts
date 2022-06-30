import { IPreloaderCard } from './../../../models/card-preloader.interface';
import { IUserCard } from './../../../models/card-user.interface';
import { IStatistics } from './../../../models/card-statistics.interface copy';
import { IMovieCard } from './../../../models/card.interface';
import { Component, Input, OnInit } from '@angular/core';
import { DialogService } from "../../dialog/dialog.service";
import { AddIntoCollectionDialogComponent } from "../../add-into-collection-dialog/add-into-collection-dialog.component";
import { MovieCollectionService } from "../../../../core/services/movie-collection.service";
import { ICollectionCard } from "../../../models/card-collection.interface";

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  public cardParameters!: IMovieCard | IStatistics | IUserCard | IPreloaderCard | ICollectionCard;

  @Input() set movieCardParameters(value: IMovieCard | IStatistics | IUserCard | IPreloaderCard | ICollectionCard) {
    this.cardParameters = value;
  }

  constructor(private dialog: DialogService) { }

  ngOnInit(): void {
  }

  openDialog(state: boolean, movieId: string, event: any) {
    event.preventDefault();
    this.dialog.open(AddIntoCollectionDialogComponent, { state, movieId });
  }
}
