import { ISideMenu } from './../../../../shared/components/side-menu/side-menu.interface';
import { Component, OnInit } from '@angular/core';
import {routes} from "../admin-routes.config";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public routes: ISideMenu[] = routes;

  constructor() { }

  ngOnInit(): void {
  }

}
