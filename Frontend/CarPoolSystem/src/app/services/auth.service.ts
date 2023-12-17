import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  identityBaseUrl = `https://localhost:7041/api/user/`;
  
  constructor(private http: HttpClient) { }

  Register(user: any) {
    let url = `https://localhost:7041/api/user/register`;
    return this.http.post(url, user, { responseType: 'text' });
  }

  Login(user: any) {
    let url = `https://localhost:7041/api/user/login`;
    let res = this.http.post(url, user, { responseType: 'text' });
    localStorage.setItem('User', JSON.stringify({ user }));
    this.isLoggedInSubject.next(true);
    return res;
  }

  logout(): void {
    localStorage.removeItem('User');
    this.isLoggedInSubject.next(false);
  }

  getLoggedInUser(): any {
    const user = localStorage.getItem('User');
    return user ? JSON.parse(user) : null;
  }

  isLoggedIn(): Observable<boolean> {
    return this.isLoggedInSubject.asObservable();
  }

  isUserLoggedIn(): boolean {
    return !!localStorage.getItem('User');
  }

  GetUserById(userid: any) {
    let url = `https://localhost:7041/api/user/getuserbyid/${userid}`;
    let data = this.http.get(url)
    return data;
  }
}
