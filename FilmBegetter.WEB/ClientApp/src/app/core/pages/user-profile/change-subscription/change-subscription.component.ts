import { render } from 'creditcardpayments/creditCardPayments';
import { Component, OnInit } from '@angular/core';
import { UserViewModel } from "../../../models/user-view-model.interface";
import { HttpErrorResponse } from "@angular/common/http";
import { UserService } from "../../../services/user.service";
import { IButton } from 'src/app/shared/models/button.interface';

@Component({
  selector: 'app-change-subscription',
  templateUrl: './change-subscription.component.html',
  styleUrls: ['./change-subscription.component.scss']
})
export class ChangeSubscriptionComponent implements OnInit {

  user!: UserViewModel;
  button!: HTMLButtonElement;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUserProfile();

    render(
      {
        id: "#myPaypalButtons",
        currency: "USD",
        value: "100.00",
        onApprove: (details) => {
          this.userService.updateUserSubscription('api/users/updateSubscription', { userId: this.user.id, type: 'Premium' }).subscribe({
            next: (data: any) => {
              console.log(data);
            },
            error: (err: HttpErrorResponse) => {
              console.log(err);
            }
          });
        }
      }
    );
  }

  getUserProfile = () => {
    this.userService.getCurrentUser("api/users/currentUser").subscribe({

      next: (data: UserViewModel) => {
        this.user = data;
        console.log(this.user);
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }

    });
  }



  public buttonConfig: IButton = {
    type: 'default',
    size: 'default',
    text: 'BUY NOW',
    disabled: false
  }

}
