import { Component, Input, OnInit } from '@angular/core';
import { AppConfig } from '@simaira-digital/the-styles-gurugram/shared';
import { CollectionBanner } from '../../../models/collection-banner';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';

@Component({
  selector: 'simairadigital-customer-collection-banner',
  templateUrl: './collection-banner.component.html',
  styleUrls: ['./collection-banner.component.scss'],
})
export class CollectionBannerComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public banners: Array<CollectionBanner>;
  public baseImageUrl = AppConfig.imageServerUrl;
  public constructor() {}

  private inialiseBanners(): void {
    this.banners = this.settings.collectionBanners;
  }

  public ngOnInit(): void {
    this.inialiseBanners();
  }
}
