import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MissingImageDirective } from './missing-image.directive';



@NgModule({
  declarations: [MissingImageDirective],
  imports: [
    CommonModule
  ],
  exports: [MissingImageDirective]
})
export class DirectivesModule { }
