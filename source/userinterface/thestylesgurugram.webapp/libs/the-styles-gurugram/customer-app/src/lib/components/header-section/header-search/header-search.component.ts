import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'simairadigital-customer-header-search',
  templateUrl: './header-search.component.html',
  styleUrls: ['./header-search.component.scss'],
})
export class HeaderSearchComponent implements OnInit {
  public isSearchBlockOpen = false;
  public constructor() {}

  public ngOnInit(): void {}

  public openSearchBox(): void {
    this.isSearchBlockOpen = true;
  }

  public closeSearchBox(): void {
    this.isSearchBlockOpen = false;
  }
}
