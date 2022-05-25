import { Component, Input, OnInit } from '@angular/core';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';
import { HeaderMenu } from '../../../models/header-menu';

@Component({
  selector: 'simairadigital-customer-header-menu',
  templateUrl: './header-menu.component.html',
  styleUrls: ['./header-menu.component.scss'],
})
export class HeaderMenuComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public headerMenu: Array<HeaderMenu>;
  public back: string;
  public constructor() {}

  private intialiseMenus(): void {
    this.headerMenu = this.settings.headerMenuSetting.menus;
  }

  public ngOnInit(): void {
    this.back = this.settings.headerMenuSetting.back;
    this.intialiseMenus();
  }

  public getObjectKeys(obj: any): Array<string> {
    return Object.keys(obj);
  }

  public getMegaClass(isMega: boolean): string {
    return isMega ? 'mega' : '';
  }

  public getMegaMenuId(isMega: boolean): string {
    return isMega ? 'hover-cls' : '';
  }
}
