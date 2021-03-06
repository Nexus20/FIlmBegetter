import { InputComponent } from './components/input/input.component';
import { PipeModule } from './pipes/pipe.module';
import { CardModule } from './components/card/card.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OverlayModule } from '@angular/cdk/overlay';
import { MatSelectModule } from '@angular/material/select';

import { ButtonComponent } from './components/button/button.component';
import { HeaderModule } from './components/header/header.module';
import { CollectionComponent } from './components/collection/collection.component';
import { RateComponent } from './components/rate/rate.component';
import { CommentComponent } from './components/comment/comment.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { DialogService } from './components/dialog/dialog.service';
import { LoaderComponent } from './components/loader/loader.component';
import { BlockViewComponent } from './components/block-view/block-view.component';
import { AddIntoCollectionDialogComponent } from './components/add-into-collection-dialog/add-into-collection-dialog.component';
import { DropdownComponent } from './components/dropdown/dropdown.component';


@NgModule({
  declarations: [
    ButtonComponent,
    InputComponent,
    CollectionComponent,
    RateComponent,
    CommentComponent,
    SideMenuComponent,
    LoaderComponent,
    BlockViewComponent,
    AddIntoCollectionDialogComponent,
    DropdownComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    HeaderModule,
    CardModule,
    PipeModule,
    FormsModule,
    OverlayModule,
    MatSelectModule,
    ReactiveFormsModule
  ],
  exports: [
    ButtonComponent,
    HeaderModule,
    InputComponent,
    CollectionComponent,
    RateComponent,
    CommentComponent,
    SideMenuComponent,
    LoaderComponent,
    BlockViewComponent,
    DropdownComponent
  ],
  providers: [DialogService]
})
export class SharedModule { }
