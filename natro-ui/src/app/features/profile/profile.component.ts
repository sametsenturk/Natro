import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user/user.service';
import { DialogComponent } from 'src/app/shared/dialog/dialog.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [UserService]
})
export class ProfileComponent implements OnInit {

  constructor(
    private userService: UserService,
    private router: Router,
    private dialog: MatDialog,
  ) { }

  email: string;

  ngOnInit(): void {
    this.setEmail();
  }

  setEmail() {
    this.email = this.userService.getEmail();
  }

  exit() {
    this.userService.exit();
    this.dialog.open(DialogComponent, {
      data: {
        Title: "Success",
        Content: "You logged out successfully"
      }
    });
    this.router.navigateByUrl("/login")
  }

}
