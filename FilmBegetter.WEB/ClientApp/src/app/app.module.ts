import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {ErrorHandlerService} from "./shared/services/error-handler.service";

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        SharedModule,
        HttpClientModule,
    ],
    providers: [
        // {
        //   provide: HTTP_INTERCEPTORS,
        //   useClass: ErrorHandlerService,
        //   multi: true
        // }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
