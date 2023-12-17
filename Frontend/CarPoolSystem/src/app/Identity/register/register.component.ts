import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { NavigationService } from 'src/app/services/navigation.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  formData: any = {};

  constructor(private authService: AuthService, private router: Router) { }
  register() {
    console.log(this.formData);
    this.authService.Register(this.formData).subscribe((res) => {
      console.log(res);
      if (res == "Registration successful") {
        this.router.navigate(['/login']);
      }
    })
  }
}
