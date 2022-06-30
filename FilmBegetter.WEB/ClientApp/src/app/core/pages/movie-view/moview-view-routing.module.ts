import { MovieViewComponent } from './component/movie-view/movie-view.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieResolverService } from '../../services/movie-resolver.service';



const routes: Routes = [
  { path: ':id', component: MovieViewComponent, resolve: { movie: MovieResolverService } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovieViewRoutingModule {
}
