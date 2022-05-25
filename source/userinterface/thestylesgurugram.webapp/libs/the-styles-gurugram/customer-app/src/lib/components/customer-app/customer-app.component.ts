import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerAppSettings } from '../../models/customer-app.settings.';

@Component({
  selector: 'simairadigital-customer-app',
  templateUrl: './customer-app.component.html',
  styleUrls: ['./customer-app.component.scss'],
})
export class CustomerAppComponent implements OnInit {
  public appSettings;
  public settingsLoaded = false;
  public constructor(private http: HttpClient) {}

  public ngOnInit(): void {
    this.loadAppSettingsConfig();
  }

  public loadAppSettingsConfig() {
    this.http
      .get(`/assets/customer-settings.json`)
      .toPromise()
      .then((appsStings) => {
        Object.assign(CustomerAppSettings, appsStings);
        this.appSettings = appsStings;
        this.settingsLoaded = true;
      });
  }
}
