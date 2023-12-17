import { Component, OnInit } from '@angular/core';
import { IOfferRide } from '../models';
import { NavigationService } from '../services/navigation.service';
import { LoginComponent } from '../Identity/login/login.component';
import { AuthService } from '../services/auth.service';
import { MyRideService } from '../services/my-ride.service';

@Component({
  selector: 'app-available-ride',
  templateUrl: './available-ride.component.html',
  styleUrls: ['./available-ride.component.css']
})
export class AvailableRideComponent implements OnInit {
  availableRides: any[] = [];
  availableRide: IOfferRide = {
    offer_Id: 1,
    name: "Roma",
    source: "Ambikapur",
    destination: "Raipur",
    car_Name: "Honda",
    seat_Available: 5,
    departureTime: new Date(),
    phone_no: 8787878787
  }

  constructor(private navigationService: NavigationService, private authService: AuthService, private cartService: MyRideService) {
    this.isActiveUser = this.authService.isUserLoggedIn();
  }
  isActiveUser: any = false;

  // ngOnInit(): void {
  //   //this.isActiveUser = this.authService.isUserLoggedIn();
  //   // //this.isActiveUser = this.authService.isLoggedIn();

  // }
  ngOnInit(): void {
    // this.authService.isLoggedIn().subscribe(isLoggedIn => {
    //   this.isActiveUser = isLoggedIn;
    // });

    this.navigationService.GetAllOfferRide().subscribe((res: any) => {
      //console.log(res);
      this.availableRides = res;
    })
  }

  BookNow(offerRide: any) {
    let user: any = this.authService.getLoggedInUser();
    console.log(user.email);

    if (user == null) {
      console.log("User Not log in");
      return;
    }
    if (user !== null) {
      this.navigationService.BookRide(user.email, offerRide.offer_Id).subscribe((res: any) => {
        console.log(res);
        if (res == "Successfully booked your Ride") {
          this.cartService.addToCart(offerRide);
        }
      });
    } else {
      console.error('User is not logged in');
    }
  }
}
