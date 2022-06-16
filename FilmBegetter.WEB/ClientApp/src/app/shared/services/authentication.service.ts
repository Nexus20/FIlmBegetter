import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { RegistrationViewModel } from "../models/registrationViewModel.interface";
import { RegistrationResponseViewModel } from "../models/registrationResponseViewModel.interface";
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

    public registerUser = (route: string, body: RegistrationViewModel) => {
        return this.http.post<RegistrationResponseViewModel> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
    }
    private createCompleteRoute = (route: string, envAddress: string) => {
        return `${envAddress}/${route}`;
    }
}
