import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { ChangeSubscriptionComponent } from './change-subscription/change-subscription.component';
import { RouterModule } from "@angular/router";
import {ReactiveFormsModule} from "@angular/forms";



@NgModule({
  declarations: [
    ProfileComponent,
    EditProfileComponent,
    ChangeSubscriptionComponent
  ],
    imports: [
        CommonModule,
        RouterModule.forChild([
            {path: '', component: ProfileComponent},
            {path: 'edit', component: EditProfileComponent},
            {path: 'subscriptions', component: ChangeSubscriptionComponent}
        ]),
        ReactiveFormsModule
    ]
})
export class UserProfileModule { }
