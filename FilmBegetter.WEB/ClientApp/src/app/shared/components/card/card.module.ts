import { CropPipe } from './../../pipes/crop.pipe';
import { PipeModule } from './../../pipes/pipe.module';
import { CardComponent } from './component/card.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from "@angular/router";



@NgModule({
    declarations: [CardComponent],
    imports: [
        CommonModule,
        PipeModule,
        RouterModule
    ],
    exports: [CardComponent]
})
export class CardModule { }
