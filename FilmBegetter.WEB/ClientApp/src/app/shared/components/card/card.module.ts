import { DirectivesModule } from './../../directives/directives.module';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { PipeModule } from './../../pipes/pipe.module';
import { CardComponent } from './component/card.component';


@NgModule({
  declarations: [CardComponent],
  imports: [
    CommonModule,
    PipeModule,
    RouterModule,
    RouterModule,
    DirectivesModule
  ],
  exports: [CardComponent]
})
export class CardModule { }
