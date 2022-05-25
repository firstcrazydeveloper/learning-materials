import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './authentication.service';

@Component({
  selector: 'serial-blok-app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'Simaira Digital';

  constructor(
    private authService: AuthenticationService,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.authService.initializeAuthentication();
    this.getUrl().subscribe(
      (data) => {
        console.log(data);
      },
      (err: any) => {
        if (err.error instanceof Error) {
          console.log('Client-side error occured.');
        } else {
          console.log('Server-side error occured.');
        }
      }
    );
  }

  public getUrl() {
    return this.http.get(
      'https://api.ecobee.com/home/api/1/thermostatSummary?json={"selection":{"selectionType":"registered","selectionMatch":""}}',
      {
        headers: new HttpHeaders({
          'user-agent': 'EU Mobile API',
          Authorization:
            'Bearer ' +
            'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IlJFWXhNVEpDT0Rnek9UaERRelJHTkRCRlFqZEdNVGxETnpaR1JUZzRNalEwTmtWR01UQkdPQSJ9.eyJpc3MiOiJodHRwczovL2F1dGguZWNvYmVlLmNvbS8iLCJzdWIiOiJhdXRoMHw5ZGI2M2NmYi1lOTc3LTRkODYtOWFiMy02YzkzN2FiMjI0NDgiLCJhdWQiOlsiaHR0cHM6Ly9kZXZlbG9wZXItYXBwcy5lY29iZWUuY29tL2FwaS92MSIsImh0dHBzOi8vZWNvYmVlLXByb2QuYXV0aDAuY29tL3VzZXJpbmZvIl0sImlhdCI6MTYxOTQ1MjQyMywiZXhwIjoxNjE5NDU2MDIzLCJhenAiOiI1RVJvMTB4MTlQcmVvaVU1TGpRaUdhb0ZueWFpVU1uaiIsInNjb3BlIjoib3BlbmlkIHNtYXJ0V3JpdGUgb2ZmbGluZV9hY2Nlc3MifQ.sNAGvaC6YkACDih9gt0HLVP03l0ZeueMGzq511OLTJcHSshUyZ1rBcaIKEkxtOdBSVVn1SPcS5zyEAoD0SCkEmw3jmvBj84XMG9u1UdicR0Fb29GTV4y2nGA16F-1lFnehlXnZpKoBzmHKO2zpu4reSmmgFeUhMR2haDtfC4_fqbzT0Dt8y84b4eIQCG4M0rGKH95oztOjFfZERv_3lQfH1xvvUbvtlBhS-lnVH56MlfW3TVchFlKGAb_mUcx_3XkFJH5rMfQ98z5wOwQIBhl5yFVDaCeR5nTGETXtgfN5RbW5Ax2DOFMVp0DsPNxCc8Dlflw0oSpUb5IGPzZFf7Uw',
        }),
      }
    );
  }

  login() {
    this.authService.login();
  }

  logOut() {
    this.authService.logout();
  }
}
