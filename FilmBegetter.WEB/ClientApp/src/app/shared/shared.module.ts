import { InputComponent } from './components/input/input.component';
import { PipeModule } from './pipes/pipe.module';
import { CardModule } from './components/card/card.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from './components/button/button.component';
import { HeaderModule } from './components/header/header.module';
import { CollectionComponent } from './components/collection/collection.component';


@NgModule({
    declarations: [
        ButtonComponent,
        InputComponent,
        CollectionComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        HeaderModule,
        CardModule,
        PipeModule
    ],
    exports: [
        ButtonComponent,
        HeaderModule,
        InputComponent,
        CollectionComponent
    ]
})
export class SharedModule { }
