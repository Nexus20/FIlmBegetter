import { DirectivesModule } from './../../../shared/directives/directives.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSliderModule } from '@angular/material/slider';

import { PipeModule } from './../../../shared/pipes/pipe.module';
import { SelectionRoutingModule } from './selection-routing.module';
import { SelectionComponent } from './component/selection.component';
import { SharedModule } from './../../../shared/shared.module';
import { SearchItemComponent } from './children/search-item/search-item.component';



@NgModule({
  declarations: [
    SelectionComponent,
    SearchItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    SelectionRoutingModule,
    ReactiveFormsModule,
    PipeModule,
    MatTooltipModule,
    MatSliderModule,
    DirectivesModule
  ],
  exports: [
    SelectionComponent
  ]
})
export class SelectionModule { }
