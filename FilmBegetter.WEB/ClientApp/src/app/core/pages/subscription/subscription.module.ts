import { SubscriptionRoutingModule } from './subscription-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { SharedModule } from './../../../shared/shared.module';
import { SubscriptionComponent } from './subscription.component';

@NgModule({
  declarations: [SubscriptionComponent],
  imports: [
    CommonModule,
    SharedModule,
    SubscriptionRoutingModule
  ],
  exports: [
    SubscriptionComponent
  ]
})
export class SubscriptionModule { }
