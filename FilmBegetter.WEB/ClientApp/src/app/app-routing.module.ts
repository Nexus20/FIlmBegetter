import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from "./shared/guards/auth.guard";
import { AdminGuard } from "./shared/guards/admin.guard";

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
    path: 'movie',
    loadChildren: () => import('./core/pages/movie-view/movie-view.module').then(m => m.MovieViewModule)
  },
  {
    path: 'subscription',
    loadChildren: () => import('./core/pages/subscription/subscription.module').then(m => m.SubscriptionModule)
  },
  {
    path: 'admin',
    loadChildren: () => import('./core/pages/admin-page/admin-page.module').then(m => m.AdminPageModule),
    canActivate: [AuthGuard, AdminGuard]
  },
  {
    path: 'profile',
    loadChildren: () => import('./core/pages/user-profile/user-profile.module').then(m => m.UserProfileModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'catalog',
    loadChildren: () => import('./core/pages/catalog/catalog.module').then(m => m.CatalogModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
