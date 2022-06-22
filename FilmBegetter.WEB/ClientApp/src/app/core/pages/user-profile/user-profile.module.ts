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



@NgModule({
  declarations: [
    ProfileComponent,
    EditProfileComponent,
    ChangeSubscriptionComponent,
    MovieCollectionsComponent,
    CollectionFormComponent,
    FriendsComponent
  ],
    imports: [
        CommonModule,
        RouterModule.forChild([
            { path: '', component: ProfileComponent },
            { path: 'edit', component: EditProfileComponent },
            { path: 'subscriptions', component: ChangeSubscriptionComponent },
            { path: 'collections', component: MovieCollectionsComponent },
            { path: 'friends', component: FriendsComponent }
        ]),
        ReactiveFormsModule
    ]
})
export class UserProfileModule { }
