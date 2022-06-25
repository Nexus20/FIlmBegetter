import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PipeModule } from './../../../shared/pipes/pipe.module';
import { SelectionRoutingModule } from './selection-routing.module';
import { SelectionComponent } from './component/selection.component';
import { SharedModule } from './../../../shared/shared.module';
import { SearchItemComponent } from './children/search-item/search-item.component';
import { NoopAnimationsModule, BrowserAnimationsModule } from '@angular/platform-browser/animations';



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
    PipeModule
  ],
  exports: [
    SelectionComponent
  ]
})
export class SelectionModule { }
