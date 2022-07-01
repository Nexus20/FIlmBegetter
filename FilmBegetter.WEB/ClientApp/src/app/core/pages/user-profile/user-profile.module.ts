import { DirectivesModule } from './../../../shared/directives/directives.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { ChangeSubscriptionComponent } from './change-subscription/change-subscription.component';
import { RouterModule } from "@angular/router";
import { ReactiveFormsModule } from "@angular/forms";
import { MovieCollectionsComponent } from './movie-collections/movie-collections.component';
import { CollectionFormComponent } from './collection-form/collection-form.component';
import { FriendsComponent } from './friends/friends.component';
import { SharedModule } from "../../../shared/shared.module";
import { CollectionViewComponent } from './collection-view/collection-view.component';
import {CardModule} from "../../../shared/components/card/card.module";



@NgModule({
  declarations: [
    ProfileComponent,
    EditProfileComponent,
    ChangeSubscriptionComponent,
    MovieCollectionsComponent,
    CollectionFormComponent,
    FriendsComponent,
    CollectionViewComponent
  ],
    imports: [
        CommonModule,
        RouterModule.forChild([
            {path: '', component: ProfileComponent},
            {path: 'edit', component: EditProfileComponent},
            {path: 'subscriptions', component: ChangeSubscriptionComponent},
            {path: 'collections', component: MovieCollectionsComponent},
            {path: 'friends', component: FriendsComponent}
        ]),
        ReactiveFormsModule,
        SharedModule,
        DirectivesModule,
        CardModule
    ]
})
export class UserProfileModule { }
