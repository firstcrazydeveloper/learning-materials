import { Component, Input, OnInit } from '@angular/core';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';

@Component({
  selector: 'simairadigital-customer-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.scss'],
})
export class ServiceComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public freeShiping: string;
  public freeShipingMessage: string;
  public customerService: string;
  public customerServiceMessage: string;
  public offer: string;
  public offerMessage: string;

  public constructor() {}

  public ngOnInit(): void {
    this.freeShiping = this.settings.service.freeShiping;
    this.freeShipingMessage = this.settings.service.freeShipingMessage;
    this.customerService = this.settings.service.customerService;
    this.customerServiceMessage = this.settings.service.customerServiceMessage;
    this.offer = this.settings.service.offer;
    this.offerMessage = this.settings.service.offerMessage;
  }
}
