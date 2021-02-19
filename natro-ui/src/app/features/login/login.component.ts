import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/core/models/user/request/loginRequest';
import { UserService } from 'src/app/core/services/user/user.service';
import { DialogComponent } from 'src/app/shared/dialog/dialog.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UserService]
})
export class LoginComponent implements OnInit {

  constructor(
    private userService: UserService,
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
         localStorage.setItem("token", res.jwt);
         localStorage.setItem("email", res.email);
         this.router.navigateByUrl("/search")
       }
    });
  }

}
