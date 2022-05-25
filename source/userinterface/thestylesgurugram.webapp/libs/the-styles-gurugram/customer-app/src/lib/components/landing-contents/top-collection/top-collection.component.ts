import { Component, Input, OnInit } from '@angular/core';
import { AppConfig } from '@simaira-digital/the-styles-gurugram/shared';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';
import { Item } from '../../../models/item';

@Component({
  selector: 'simairadigital-customer-top-collection',
  templateUrl: './top-collection.component.html',
  styleUrls: ['./top-collection.component.scss'],
})
export class TopCollectionComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public sectionTitle: string;
  public sectionSubTitle: string;
  public sectionMessage: string;
  public items: Array<Item>;
  public counter = Array;
  public constructor() {}
  public baseImageUrl = AppConfig.imageServerUrl;

  private intialiseTopCollections(): void {
    this.sectionTitle = this.settings.topCollection.sectionTitle;
    this.sectionSubTitle = this.settings.topCollection.sectionSubTitle;
    this.sectionMessage = this.settings.topCollection.sectionMessage;
    this.items = this.settings.topCollection.items;
  }

  public ngOnInit(): void {
    this.intialiseTopCollections();
  }

  public getNumberArray(value: number): any {
    // tslint:disable-next-line: no-unused-expression
    new Array(value);
  }
}
