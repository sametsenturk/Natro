import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/core/models/user/request/loginRequest';
import { NotificationService } from 'src/app/core/services/notification/notification.service';
import { UserService } from 'src/app/core/services/user/user.service';
import { DialogComponent } from 'src/app/shared/dialog/dialog.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UserService, NotificationService]
})
export class LoginComponent implements OnInit {

  constructor(
    private userService: UserService,
    private notificationService: NotificationService,
    private dialog: MatDialog,
    private router: Router
  ) { }

  request: LoginRequest;

  ngOnInit(): void {
    this.request = new LoginRequest();
  }

  signIn() {
    this.userService.login(this.request).subscribe(res => {
       if(!res.isSuccess) {
         console.log(res);
          this.dialog.open(DialogComponent, {
            data: {
              Title: "Error",
              Content: res.errorMessage
            }
          });
       } else {        
         localStorage.removeItem("token");
         localStorage.removeItem("email");
         localStorage.setItem("token", res.jwt);
         localStorage.setItem("email", res.email);
         this.router.navigateByUrl("/search");
         this.showNotifications();
       }
    });
  }

  showNotifications() {
    this.notificationService.getNotifications().subscribe(res => {
      if(!res.isSuccess) {
        this.dialog.open(DialogComponent, {
          data: {
            Title: "Error",
            Content: "Something went wrong when trying to get notifications"
          }
        });
      } else {
        res.userFavoriteNotifications.map(x => {
          this.dialog.open(DialogComponent, {
            data: {
              Title: "Notification",
              Content: `${x.userFavorite.domain} now available to buy !`
            }
          });
        })
      }
    });
  }

}
