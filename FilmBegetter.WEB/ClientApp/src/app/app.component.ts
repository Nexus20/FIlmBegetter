import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from "./shared/services/authentication.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private authService: AuthenticationService){}

  ngOnInit(): void {

      if(this.authService.isUserAuthenticated()) {
          this.authService.sendAuthStateChangeNotification({
              isAuthenticated: true,
              isAdmin: this.authService.isUserAdmin(),
              isModer: this.authService.isUserModerator()
          });
      }
  }
}
