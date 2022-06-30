import { ISideMenu } from './../../../../shared/components/side-menu/side-menu.interface';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {


  public routes: ISideMenu[] = [
    {
      icon: 'video-play',
      route: 'admin/movies',
      label: 'Movies'
    },
    {
      icon: 'video-play',
      route: 'admin/movies/new',
      label: 'New movie'
    },
    {
      icon: 'person',
      route: 'admin/users',
      label: 'Users'
    },
    {
      icon: 'statistics',
      route: '',
      label: 'Statistics'
    },

  ];

  constructor() { }

  ngOnInit(): void {
  }

}
