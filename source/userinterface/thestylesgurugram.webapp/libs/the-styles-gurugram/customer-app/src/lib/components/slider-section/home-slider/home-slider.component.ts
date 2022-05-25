import { Component, Input, OnInit } from '@angular/core';
import { AppConfig } from '@simaira-digital/the-styles-gurugram/shared';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';
import { Slider } from '../../../models/slider';

@Component({
  selector: 'simairadigital-customer-home-slider',
  templateUrl: './home-slider.component.html',
  styleUrls: ['./home-slider.component.scss'],
})
export class HomeSliderComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public sliders: Array<Slider>;
  public shopNow: string;
  public baseImageUrl = AppConfig.imageServerUrl;
  public constructor() {}

  private intialiseSlider(): void {
    this.sliders = this.settings.homeSliderSettings.sliders;
    this.shopNow = this.settings.homeSliderSettings.shopNow;
  }

  public ngOnInit(): void {
    this.intialiseSlider();
  }
}
