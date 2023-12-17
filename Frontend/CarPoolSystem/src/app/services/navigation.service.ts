import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  offerBaseUrl = `https://localhost:7046/api/OfferRide/`;
  identityBaseUrl = `https://localhost:7041/api/user/`;
  apiGatewayBaseUrl = "https://localhost:7130/api/OfferRide/";
  constructor(private http: HttpClient) { }

  GetAllOfferRide() {
    let url = this.apiGatewayBaseUrl + "All";
    return this.http.get<any[]>(url);
  }

  CreateOfferRide(offerRide: any) {
    let url = this.apiGatewayBaseUrl + "Offer";
    return this.http.post(url, offerRide, { responseType: 'text' });
  }

  BookRide(userid: any, rideid: any) {
    let url = `https://localhost:7055/api/booking/BookRide?userId=${userid}&rideId=${rideid}`;
    return this.http.post(url, null, { responseType: 'text' });
  }




}
