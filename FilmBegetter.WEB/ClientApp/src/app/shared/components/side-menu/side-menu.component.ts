import { Component, Input, OnInit } from '@angular/core';
import { ISideMenu } from './side-menu.interface';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.scss']
})
export class SideMenuComponent implements OnInit {


  @Input() routes!: ISideMenu[];

  constructor() { }

  ngOnInit(): void {
  }

}
