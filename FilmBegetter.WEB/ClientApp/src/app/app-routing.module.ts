import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./core/pages/selection/selection.module').then(m => m.SelectionModule)
    },
    {
        path: 'test',
        loadChildren: () => import('./shared/components/test-ui/test.module').then(m => m.TestModule)
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
