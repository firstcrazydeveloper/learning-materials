import { Component, Input, OnInit } from '@angular/core';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';

@Component({
  selector: 'simairadigital-customer-header-settings',
  templateUrl: './header-settings.component.html',
  styleUrls: ['./header-settings.component.scss'],
})
export class HeaderSettingsComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public languageTitle: string;
  public currencyTitle: string;
  public languages: Array<string>;
  public currencies: Array<string>;
  public constructor() {}

  private intialiseLanguages(): void {
    this.languages = this.settings.customerSettings.languages;
  }

  private intialiseCurrencies(): void {
    this.currencies = this.settings.customerSettings.currencies;
  }

  public ngOnInit(): void {
    this.languageTitle = this.settings.customerSettings.languageTitle;
    this.currencyTitle = this.settings.customerSettings.currencyTitle;
    this.intialiseLanguages();
    this.intialiseCurrencies();
  }
}
