import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SelectionRoutingModule } from './selection-routing.module';
import { SelectionComponent } from './component/selection.component';
import { SharedModule } from './../../../shared/shared.module';



@NgModule({
    declarations: [
        SelectionComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        SelectionRoutingModule
    ],
    exports: [
        SelectionComponent
    ]
})
export class SelectionModule { }
