import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'simairadigital-customer-header-nav-menu',
  templateUrl: './header-nav-menu.component.html',
  styleUrls: ['./header-nav-menu.component.scss'],
})
export class HeaderNavMenuComponent implements OnInit {
  @Input() public settings: any;
  public constructor() {}

  public ngOnInit(): void {}
}
