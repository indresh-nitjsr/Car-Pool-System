import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { NavigationService } from 'src/app/services/navigation.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formData: any = {};
  isActiveUser = true;

  constructor(private authService: AuthService, private router: Router) { }
  ngOnInit(): void {
    let user = this.authService.getLoggedInUser();
    if (user == null) {
      this.isActiveUser = false;
    }
  }
  login() {
    this.authService.Login(this.formData).subscribe((res: any) => {
      if (res == "Login successful") {
        //this.currentUser = this.formData.email;
        this.router.navigate(['/available-ride']);
      }
    })
  }



}
