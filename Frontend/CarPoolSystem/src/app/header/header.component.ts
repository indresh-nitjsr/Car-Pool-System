import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isActiveUser: any = false;

  constructor(private authService: AuthService) {
    this.isActiveUser = authService.isUserLoggedIn();
  }

  ngOnInit(): void {
    //this.isActiveUser = this.authService.isUserLoggedIn();
    // //this.isActiveUser = this.authService.isLoggedIn();
    this.authService.isLoggedIn().subscribe(isLoggedIn => {
      this.isActiveUser = isLoggedIn;
    });
  }
}
