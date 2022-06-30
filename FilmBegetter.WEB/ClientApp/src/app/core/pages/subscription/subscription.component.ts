import { IButton } from './../../../shared/models/button.interface';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.scss']
})
export class SubscriptionComponent implements OnInit {

  public buttonConfig: IButton = {
    type: 'default',
    size: 'default',
    text: 'BUY NOW',
    disabled: false
  }

  constructor() { }

  ngOnInit(): void {
  }

}
