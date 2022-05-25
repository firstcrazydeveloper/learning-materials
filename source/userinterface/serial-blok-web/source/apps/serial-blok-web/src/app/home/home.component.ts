import { Component } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { User } from '../user';

@Component({
  selector: 'serial-blok-app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  title = 'Simaira Digital';
  public constructor(private authService: AuthenticationService) {}

  public get user(): User {
    return this.authService.currentUser;
  }

  public logOut() {
    this.authService.logout();
  }
}
