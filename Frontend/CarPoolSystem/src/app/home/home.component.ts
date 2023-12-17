import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  isActiveUser: any = false;


  constructor(private authService: AuthService, private router: Router) {
    let res = this.authService.isUserLoggedIn();
    if (res) {
      this.router.navigate(['/available-ride']);
    }
  }
  ngOnInit(): void {
  }
}
