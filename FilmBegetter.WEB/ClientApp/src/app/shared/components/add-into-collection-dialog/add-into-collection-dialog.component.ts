import {Component, Inject, OnInit} from '@angular/core';
import {DialogRef} from "../dialog/dialog-ref";
import {DIALOG_DATA} from "../dialog/dialog-token";
import {MovieCollectionService} from "../../../core/services/movie-collection.service";
import {MovieCollectionViewModel} from "../../../core/models/movie-collection-view-model.interface";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-add-into-collection-dialog',
  templateUrl: './add-into-collection-dialog.component.html',
  styleUrls: ['./add-into-collection-dialog.component.scss']
})
export class AddIntoCollectionDialogComponent implements OnInit {

    public isAddingMode: boolean = false;

    movieCollections!: MovieCollectionViewModel[];

    constructor(private movieCollectionService: MovieCollectionService,
              private dialogRef: DialogRef,
              @Inject(DIALOG_DATA) public data: { state: boolean }) { }

    ngOnInit(): void {
      this.isAddingMode = this.data.state;
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
                console.log(this.movieCollections);
            },
            error: (error: HttpErrorResponse) => {
                console.log(error);
            }
        });
    }
}
