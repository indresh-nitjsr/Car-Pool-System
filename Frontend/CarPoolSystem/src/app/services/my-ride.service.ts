import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MyRideService {
  private cartItems: any[] = [];
  constructor() { }

  addToCart(item: any): void {
    this.cartItems.push(item);
  }

  removeFromCart(index: number): void {
    this.cartItems.splice(index, 1);
  }

  getCartItems(): any[] {
    return this.cartItems;
  }
}
