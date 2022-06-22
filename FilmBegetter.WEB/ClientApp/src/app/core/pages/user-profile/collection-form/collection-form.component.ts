import {Component, Input, OnInit} from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import {HttpErrorResponse} from "@angular/common/http";
import {MovieCollectionService} from "../../../services/movie-collection.service";

@Component({
  selector: 'app-collection-form',
  templateUrl: './collection-form.component.html',
  styleUrls: ['./collection-form.component.css']
})
export class CollectionFormComponent implements OnInit {

    @Input() authorId: string = '';

    collectionForm: FormGroup;

    constructor(private collectionService: MovieCollectionService) {
        this.collectionForm = new FormGroup({
            id: new FormControl('', [Validators.required]),
            name: new FormControl('', [Validators.required]),
            authorId: new FormControl('', [Validators.required]),
        });
    }

    ngOnInit(): void {

        this.collectionForm = new FormGroup({
            id: new FormControl('', [Validators.required]),
            name: new FormControl('', [Validators.required]),
            authorId: new FormControl('', [Validators.required]),
        });
    }

    validateControl = (controlName: string) => {
        return this.collectionForm.get(controlName)?.invalid && this.collectionForm.get(controlName)?.touched
    }

    hasError = (controlName: string, errorName: string) => {
        return this.collectionForm.get(controlName)?.hasError(errorName)
    }

    sendCollectionForm(collectionFormValue: any) {

        if(collectionFormValue.id.value) {
            this.collectionService.update("api/collections/update", collectionFormValue).subscribe({
                next: (res: any) => {
                    console.log(res);
                },
                error: (err: HttpErrorResponse) => {
                    console.log(err)
                    // this.errorMessage = err.message;
                    // this.showError = true;
                }
            });
        } else {
            this.collectionService.create("api/collections/update", collectionFormValue).subscribe({
                next: (res: any) => {
                    console.log(res);
                },
                error: (err: HttpErrorResponse) => {
                    console.log(err)
                    // this.errorMessage = err.message;
                    // this.showError = true;
                }
            });
        }


    }
}
