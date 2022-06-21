import { Component, OnInit } from '@angular/core';
import { UserViewModel } from "../../../models/user-view-model.interface";
import { HttpErrorResponse } from "@angular/common/http";
import { UserService } from "../../../services/user.service";
import { render } from "creditcardpayments/creditCardPayments";

@Component({
  selector: 'app-change-subscription',
  templateUrl: './change-subscription.component.html',
  styleUrls: ['./change-subscription.component.css']
})
export class ChangeSubscriptionComponent implements OnInit {

    user!: UserViewModel;

    constructor(private userService: UserService) { }

    ngOnInit(): void {
        this.getUserProfile();

        render(
            {
                id: "#myPaypalButtons",
                currency: "USD",
                value: "100.00",
                onApprove: (details) => {
                    console.log('success');
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

}
