import { IButton } from './../../models/button.interface';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-block-view',
  templateUrl: './block-view.component.html',
  styleUrls: ['./block-view.component.scss']
})
export class BlockViewComponent implements OnInit {

  @Input() direction: 'horizontal' | 'vertical' = 'horizontal';

  public addCommentButton: IButton = {
    type: 'default',
    size: 'default',
    text: 'Subscription',
    disabled: false
  }

  constructor() { }

  ngOnInit(): void {
  }

}
