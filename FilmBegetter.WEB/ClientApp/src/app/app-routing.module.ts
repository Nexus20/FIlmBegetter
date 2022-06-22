import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthGuard} from "./shared/guards/auth.guard";

const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./core/pages/selection/selection.module').then(m => m.SelectionModule)
    },
    {
        path: 'test',
        loadChildren: () => import('./shared/components/test-ui/test.module').then(m => m.TestModule),
        canActivate: [AuthGuard]
    },
    {
        path: 'authentication',
        loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule)
    },
    {
        path: 'admin',
        loadChildren: () => import('./core/pages/admin-page/admin-page.module').then(m => m.AdminPageModule)
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
