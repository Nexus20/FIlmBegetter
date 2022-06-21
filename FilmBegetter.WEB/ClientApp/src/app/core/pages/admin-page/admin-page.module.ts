import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { MoviesComponent } from './movies/movies.component';
import { UsersComponent } from './users/users.component';
import {RouterModule} from "@angular/router";



@NgModule({
  declarations: [
    HomeComponent,
    MoviesComponent,
    UsersComponent
  ],
  imports: [
    CommonModule,
      RouterModule.forChild([
          { path: 'home', component: HomeComponent },
          { path: 'movies', component: MoviesComponent },
          { path: 'users', component: UsersComponent }
      ])
  ]
})
export class AdminPageModule { }
