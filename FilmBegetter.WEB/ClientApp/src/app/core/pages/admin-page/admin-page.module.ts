import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { MoviesComponent } from './movies/movies.component';
import { UsersComponent } from './users/users.component';
import {RouterModule} from "@angular/router";
import { MovieCreationFormComponent } from './movie-creation-form/movie-creation-form.component';
import {ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../../../shared/shared.module";



@NgModule({
  declarations: [
    HomeComponent,
    MoviesComponent,
    UsersComponent,
    MovieCreationFormComponent
  ],
    imports: [
        CommonModule,
        RouterModule.forChild([
            {path: '', component: HomeComponent},
            {path: 'movies', component: MoviesComponent},
            {path: 'users', component: UsersComponent},
            {path: 'movies/new', component: MovieCreationFormComponent}
        ]),
        ReactiveFormsModule,
        SharedModule
    ]
})
export class AdminPageModule { }
