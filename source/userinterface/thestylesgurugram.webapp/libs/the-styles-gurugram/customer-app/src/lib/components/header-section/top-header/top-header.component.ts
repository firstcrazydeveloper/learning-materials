import { Component, Input, OnInit } from '@angular/core';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';

@Component({
  selector: 'simairadigital-customer-top-header',
  templateUrl: './top-header.component.html',
  styleUrls: ['./top-header.component.scss'],
})
export class TopHeaderComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public contacts: Array<string> = [];
  public accountMenus: Array<string> = [];
  public topHeaderMessage: string;
  public myAccount: string;
  public constructor() {}

  private intialiseContacts(): void {
    this.contacts = this.settings.topHeader.contacts;
  }

  private intialiseAccountMenus(): void {
    this.accountMenus = this.settings.topHeader.accountMenus;
  }

  public ngOnInit(): void {
    this.topHeaderMessage = this.settings.topHeader.topHeaderMessage;
    this.myAccount = this.settings.topHeader.myAccount;
    this.intialiseContacts();
    this.intialiseAccountMenus();
  }
}
