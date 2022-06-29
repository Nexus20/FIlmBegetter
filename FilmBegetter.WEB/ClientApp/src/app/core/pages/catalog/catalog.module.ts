import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatalogComponent } from './catalog/catalog.component';
import { RouterModule } from "@angular/router";
import {SharedModule} from "../../../shared/shared.module";
import { CatalogSearchComponent } from './catalog-search/catalog-search.component';


@NgModule({
  declarations: [
    CatalogComponent,
    CatalogSearchComponent
  ],
    imports: [
        CommonModule,
        RouterModule.forChild([
            {path: '', component: CatalogComponent},
        ]),
        SharedModule
    ]
})
export class CatalogModule { }
