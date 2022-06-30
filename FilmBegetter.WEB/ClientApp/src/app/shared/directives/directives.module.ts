import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MissingImageDirective } from './missing-image.directive';
import { HiddenDirective } from './hidden.directive';



@NgModule({
  declarations: [MissingImageDirective, HiddenDirective],
  imports: [
    CommonModule
  ],
  exports: [MissingImageDirective, HiddenDirective]
})
export class DirectivesModule { }
