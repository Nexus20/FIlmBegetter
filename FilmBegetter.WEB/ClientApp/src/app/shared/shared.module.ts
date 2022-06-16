import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from './components/button/button.component';
import { HeaderModule } from './components/header/header.module';



@NgModule({
    declarations: [
        ButtonComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        HeaderModule
    ],
    exports: [
        ButtonComponent,
        HeaderModule
    ]
})
export class SharedModule { }
