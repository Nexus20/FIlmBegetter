import { CropPipe } from './crop.pipe';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [CropPipe],
    imports: [
        CommonModule
    ],
    exports: [CropPipe]
})
export class PipeModule { }
