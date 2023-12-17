import { Component, OnInit } from '@angular/core';
import { IOfferRide } from '../models';
import { NavigationService } from '../services/navigation.service';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-ride',
  templateUrl: './create-ride.component.html',
  styleUrls: ['./create-ride.component.css']
})
export class CreateRideComponent implements OnInit {
  isActiveUser: any = false;
  ngOnInit(): void {
    this.authService.isLoggedIn().subscribe(isLoggedIn => {
      this.isActiveUser = isLoggedIn;
    });
  }
  formData: any = {};
  // availableRide: IOfferRide = {
  //   offer_Id: 0,
  //   name: '',
  //   source: '',
  //   destination: '',
  //   car_Name: '',
  //   seat_Available: 0,
  //   departureTime: new Date(),
  //   phone_no: 0
  // }


  constructor(private navigationService: NavigationService, private authService: AuthService, private router: Router) { }
  submitForm() {
    this.navigationService.CreateOfferRide(this.formData).subscribe((res: any) => {
      console.log(res);
      this.router.navigate(['/available-ride']);
    })
  }
}
