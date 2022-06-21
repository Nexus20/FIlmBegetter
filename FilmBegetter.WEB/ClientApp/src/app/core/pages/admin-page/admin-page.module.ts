import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { MoviesComponent } from './movies/movies.component';
import { UsersComponent } from './users/users.component';



@NgModule({
  declarations: [
    HomeComponent,
    MoviesComponent,
    UsersComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AdminPageModule { }
