import { Component, Input, OnInit } from '@angular/core';
import { AppConfig } from '@simaira-digital/the-styles-gurugram/shared';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';
import { ParallaxBanner } from '../../../models/parallax-banner';

@Component({
  selector: 'simairadigital-customer-parallax-banner',
  templateUrl: './parallax-banner.component.html',
  styleUrls: ['./parallax-banner.component.scss'],
})
export class ParallaxBannerComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public parallaxBanner: ParallaxBanner;
  public baseImageUrl = AppConfig.imageServerUrl;
  public constructor() {}

  public ngOnInit(): void {
    this.parallaxBanner =  this.settings.parallaxBanner;
  }
}
