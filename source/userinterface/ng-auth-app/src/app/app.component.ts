import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SecureApp';

  weatherData;
  constructor(private authService: AuthService, private http: HttpClient) { }

  ngOnInit() {
    this.authService.initializeAuth();
  }

  login() {
    this.authService.logIn();
  }

  logOut() {
    this.authService.logOut();
  }
}
