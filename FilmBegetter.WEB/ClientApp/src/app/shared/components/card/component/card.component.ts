import { IPreloaderCard } from './../../../models/card-preloader.interface';
import { IUserCard } from './../../../models/card-user.interface';
import { IStatistics } from './../../../models/card-statistics.interface copy';
import { IMovieCard } from './../../../models/card.interface';
import { Component, Input, OnInit } from '@angular/core';
import {DialogService} from "../../dialog/dialog.service";
import {AddIntoCollectionDialogComponent} from "../../add-into-collection-dialog/add-into-collection-dialog.component";
import {MovieCollectionService} from "../../../../core/services/movie-collection.service";

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  public cardParameters!: IMovieCard | IStatistics | IUserCard | IPreloaderCard;

  @Input() set movieCardParameters(value: IMovieCard | IStatistics | IUserCard | IPreloaderCard) {
    this.cardParameters = value;
  }

  constructor(private dialog: DialogService) { }

  ngOnInit(): void {
  }

    openDialog(state: boolean) {
        this.dialog.open(AddIntoCollectionDialogComponent, { state });
    }
}
