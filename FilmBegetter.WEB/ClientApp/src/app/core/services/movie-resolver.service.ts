import { MovieViewModel } from './../models/movieViewModel.interface';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { MovieService } from './movie.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieResolverService {

  constructor(private movieService: MovieService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): MovieViewModel | Observable<MovieViewModel> | Promise<MovieViewModel> {
    return this.movieService.getMovie(`api/movies/${route.paramMap.get('id')}`);
  }
}
