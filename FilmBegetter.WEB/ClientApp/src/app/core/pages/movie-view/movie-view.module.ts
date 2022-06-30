import { DirectivesModule } from './../../../shared/directives/directives.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './../../../shared/shared.module';
import { HeaderModule } from './../../../shared/components/header/header.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieViewComponent } from './component/movie-view/movie-view.component';
import { MovieFieldComponent } from './children/movie-field/movie-field.component';
import { MovieViewRoutingModule } from './moview-view-routing.module';



@NgModule({
  declarations: [
    MovieViewComponent,
    MovieFieldComponent
  ],
  imports: [
    CommonModule,
    MovieViewRoutingModule,
    HeaderModule,
    SharedModule,
    ReactiveFormsModule,
    DirectivesModule
  ],
  exports: [
    MovieViewComponent
  ]
})
export class MovieViewModule { }
