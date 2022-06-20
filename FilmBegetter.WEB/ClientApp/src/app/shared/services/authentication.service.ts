import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EnvironmentUrlService } from './environment-url.service';
import { BehaviorSubject } from "rxjs";
import { JwtHelperService } from "@auth0/angular-jwt";
import { AuthenticationViewModel } from "../../core/models/authenticationViewModel.interface";
import { AuthenticationResponseViewModel } from "../../core/models/authenticationResponseViewModel.interface";
import { RegistrationResponseViewModel } from "../../core/models/registrationResponseViewModel.interface";
import { RegistrationViewModel } from "../../core/models/registrationViewModel.interface";

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
