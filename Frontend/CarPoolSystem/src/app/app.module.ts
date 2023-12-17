import { NgModule, createComponent } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { RouterModule, Routes } from '@angular/router';
import { CreateRideComponent } from './create-ride/create-ride.component';
import { AvailableRideComponent } from './available-ride/available-ride.component';
import { LoginComponent } from './Identity/login/login.component';
import { RegisterComponent } from './Identity/register/register.component';
import { FormsModule } from '@angular/forms';
import { MyRideComponent } from './my-ride/my-ride.component';
import { LogoutComponent } from './Identity/logout/logout.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'create-ride', component: CreateRideComponent },
  { path: 'available-ride', component: AvailableRideComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'my-ride', component: MyRideComponent },
  { path: 'logout', component: LogoutComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    CreateRideComponent,
    AvailableRideComponent,
    LoginComponent,
    RegisterComponent,
    MyRideComponent,
    LogoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
