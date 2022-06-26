import { InputComponent } from './components/input/input.component';
import { PipeModule } from './pipes/pipe.module';
import { CardModule } from './components/card/card.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ButtonComponent } from './components/button/button.component';
import { HeaderModule } from './components/header/header.module';
import { CollectionComponent } from './components/collection/collection.component';
import { RateComponent } from './components/rate/rate.component';
import { CommentComponent } from './components/comment/comment.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { MissingImageDirective } from './directives/missing-image.directive';


@NgModule({
  declarations: [
    ButtonComponent,
    InputComponent,
    CollectionComponent,
    RateComponent,
    CommentComponent,
    SideMenuComponent,
    MissingImageDirective
  ],
  imports: [
    CommonModule,
    RouterModule,
    HeaderModule,
    CardModule,
    PipeModule,
    FormsModule,
  ],
  exports: [
    ButtonComponent,
    HeaderModule,
    InputComponent,
    CollectionComponent,
    RateComponent,
    CommentComponent,
    SideMenuComponent,
    MissingImageDirective
  ]
})
export class SharedModule { }
