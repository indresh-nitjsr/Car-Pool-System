import { Component } from '@angular/core';
import { MyRideService } from '../services/my-ride.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-my-ride',
  templateUrl: './my-ride.component.html',
  styleUrls: ['./my-ride.component.css']
})
export class MyRideComponent {
  cartRides: any[];

  isActiveUser: any = false;
  ngOnInit(): void {
    this.authService.isLoggedIn().subscribe(isLoggedIn => {
      this.isActiveUser = isLoggedIn;
    });
  }

  constructor(private cartService: MyRideService, private authService: AuthService) {
    this.cartRides = this.cartService.getCartItems();
  }
  removeFromCart(ride: any): void {
    this.cartService.removeFromCart(ride);
    this.cartRides = this.cartService.getCartItems();
  }
}
