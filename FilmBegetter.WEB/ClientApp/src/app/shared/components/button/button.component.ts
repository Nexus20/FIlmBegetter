import { IButton } from './../../models/button.interface';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
  @Input() buttonConfig!: IButton;
  @Input() type: 'button' | 'submit' = 'button';
  @Input() disabled: boolean = false;
  @Input() image?: string;
  @Input() text?: string;

  constructor() { }

  ngOnInit(): void {
  }

}
