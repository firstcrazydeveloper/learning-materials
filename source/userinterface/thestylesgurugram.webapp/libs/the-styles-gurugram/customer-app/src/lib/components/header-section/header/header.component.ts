import { Component, Input, OnInit } from '@angular/core';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';

@Component({
  selector: 'simairadigital-customer-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;

  public constructor() {}

  public ngOnInit(): void {
  }
}
