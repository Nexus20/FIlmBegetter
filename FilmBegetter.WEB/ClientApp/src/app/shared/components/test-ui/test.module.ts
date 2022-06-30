import { ReactiveFormsModule } from '@angular/forms';
import { CardModule } from './../card/card.module';
import { SharedModule } from './../../shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TestRoutingModule } from './test-routing.module';
import { TestComponent } from './test/test.component';
import { InputComponent } from '../input/input.component';



@NgModule({
  declarations: [
    TestComponent,

  ],
  imports: [
    CommonModule,
    TestRoutingModule,
    SharedModule,
    CardModule,
    ReactiveFormsModule
  ],
  exports: [
    TestComponent
  ]
})
export class TestModule { }
