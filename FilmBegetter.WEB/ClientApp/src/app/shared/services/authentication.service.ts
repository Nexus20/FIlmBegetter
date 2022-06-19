import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { RegistrationViewModel } from "../models/registrationViewModel.interface";
import { RegistrationResponseViewModel } from "../models/registrationResponseViewModel.interface";
import { EnvironmentUrlService } from './environment-url.service';
import { AuthenticationViewModel } from "../models/authenticationViewModel.interface";
import { AuthenticationResponseViewModel } from "../models/authenticationResponseViewModel.interface";
import {BehaviorSubject, Subject} from "rxjs";
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

    private authChangeSub = new BehaviorSubject<boolean>(false)

    public authChanged = this.authChangeSub.asObservable();

    constructor(private http: HttpClient, private envUrl: EnvironmentUrlService, private jwtHelper: JwtHelperService) { }

    public registerUser = (route: string, body: RegistrationViewModel) => {
        return this.http.post<RegistrationResponseViewModel> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    public loginUser = (route: string, body: AuthenticationViewModel) => {
        return this.http.post<AuthenticationResponseViewModel> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }

    public logout = () => {
        localStorage.removeItem("token");
        this.sendAuthStateChangeNotification(false);
    }

    public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
      this.authChangeSub.next(isAuthenticated);
    }

    public isUserAuthenticated = (): boolean => {

      const token = localStorage.getItem("token");

      return token != null && token != '' && !this.jwtHelper.isTokenExpired(token!);
    }

    public isUserAdmin = (): boolean => {
        const token = localStorage.getItem("token");
        const decodedToken = this.jwtHelper.decodeToken(token!);
        const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
        return role === 'Admin';
    }

    public isUserModerator = (): boolean => {
      const token = localStorage.getItem("token");
      const decodedToken = this.jwtHelper.decodeToken(token!);
      const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
      return role === 'Moderator';
    }

    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
