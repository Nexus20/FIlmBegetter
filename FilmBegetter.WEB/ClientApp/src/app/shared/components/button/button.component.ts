import { IButton } from './../../models/button.interface';
import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'app-button',
    templateUrl: './button.component.html',
    styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
    @Input() buttonConfig!: IButton;

    constructor() { }

    ngOnInit(): void {
    }

}
