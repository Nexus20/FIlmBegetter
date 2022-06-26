import { AuthenticationComponent } from './component/authentication/authentication.component';
import { NgModule } from '@angular/core';
import { RegisterUserComponent } from './register-user/register-user.component';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
  { path: 'register', component: RegisterUserComponent },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AuthenticationRoutingModule { }
