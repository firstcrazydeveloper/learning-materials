import { Component, Input, OnInit } from '@angular/core';
import { AppConfig } from '@simaira-digital/the-styles-gurugram/shared';
import { TabItem } from '../../../models/tab-item';
import { Item } from '../../../models/item';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';

@Component({
  selector: 'simairadigital-customer-tab-product',
  templateUrl: './tab-product.component.html',
  styleUrls: ['./tab-product.component.scss'],
})
export class TabProductComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public heading: string;
  public title: string;
  public tabs: Array<TabItem>;
  public counter = Array;
  public baseImageUrl = AppConfig.imageServerUrl;

  public constructor() {}

  private intialiseTabs(): void {
    this.heading = this.settings.tabProduct.heading;
    this.title = this.settings.tabProduct.title;
    this.tabs = this.settings.tabProduct.tabs;
  }

  public ngOnInit(): void {
    this.intialiseTabs();
  }

  public getNumberArray(value: number): any {
    // tslint:disable-next-line: no-unused-expression
    new Array(value);
  }
}
