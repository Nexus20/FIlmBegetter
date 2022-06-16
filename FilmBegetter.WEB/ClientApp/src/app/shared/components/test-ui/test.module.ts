import { SharedModule } from './../../shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TestRoutingModule } from './test-routing.module';
import { TestComponent } from './test/test.component';
import { InputComponent } from '../input/input.component';



@NgModule({
    declarations: [
        TestComponent,
        InputComponent
    ],
    imports: [
        CommonModule,
        TestRoutingModule,
        SharedModule
    ],
    exports: [
        TestComponent
    ]
})
export class TestModule { }
