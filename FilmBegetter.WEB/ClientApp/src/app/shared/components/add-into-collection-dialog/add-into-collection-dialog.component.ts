import {Component, Inject, OnInit} from '@angular/core';
import {DialogRef} from "../dialog/dialog-ref";
import {DIALOG_DATA} from "../dialog/dialog-token";
import {MovieCollectionService} from "../../../core/services/movie-collection.service";
import {MovieCollectionViewModel} from "../../../core/models/movie-collection-view-model.interface";
import {HttpErrorResponse} from "@angular/common/http";
import {ICollectionCard} from "../../models/card-collection.interface";
import {IButton} from "../../models/button.interface";
import {AddMovieToCollectionViewModel} from "../../../core/models/add-movie-to-collection-view-model.interface";

@Component({
  selector: 'app-add-into-collection-dialog',
  templateUrl: './add-into-collection-dialog.component.html',
  styleUrls: ['./add-into-collection-dialog.component.scss']
})
export class AddIntoCollectionDialogComponent implements OnInit {

    public isAddingMode: boolean = false;
    public movieId!: string;

    movieCollections!: MovieCollectionViewModel[];
    movieCollectionCards!: ICollectionCard[];

    addIntoCollectionButtonConfig: IButton = {
        disabled: false, size: "small", text: "+", type: "success"
    };

    constructor(private movieCollectionService: MovieCollectionService,
              private dialogRef: DialogRef,
              @Inject(DIALOG_DATA) public data: { state: boolean, movieId: string }) { }

    ngOnInit(): void {
        this.isAddingMode = this.data.state;
        this.movieId = this.data.movieId;
        this.getCurrentUserCollections();
    }

    public changeState(): void {
        this.isAddingMode = !this.isAddingMode;
    }

    public close(): void {
        this.dialogRef.close();
    }

    private getCurrentUserCollections() {

        this.movieCollectionService.getCurrentUserCollections("api/collections/currentUser").subscribe({
            next: (data: MovieCollectionViewModel[]) => {
                console.log(data);
                this.movieCollections = data;

                this.movieCollectionCards = data.map(e => <ICollectionCard>{
                    type: "collection",
                    info: e
                })

                console.log(this.movieCollections);
            },
            error: (error: HttpErrorResponse) => {
                console.log(error);
            }
        });
    }

    addIntoCollection(collectionId: string) {

        const body : AddMovieToCollectionViewModel = {
            collectionId: collectionId,
            movieId: this.movieId
        };

        this.movieCollectionService.addMovie(`api/collections/${collectionId}/add-movie`, body).subscribe({
            next: (data: any) => {
                console.log(data);
            },
            error: (error: HttpErrorResponse) => {
                console.log(error);
            }
        });
    }
}

