import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from "../../services/authentication.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public isUserAuthenticated!: boolean;

  burgerIsOpen: boolean = false;

  constructor(private authService: AuthenticationService, private router: Router) {
  }

  ngOnInit(): void {
    this.authService.authChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;
      });
  }

  public logout = () => {
    this.authService.logout();
    this.router.navigate(["/"]);
  }

  public openLogin(state: boolean): void {
    this.authService.openModal(state);
  }


}
