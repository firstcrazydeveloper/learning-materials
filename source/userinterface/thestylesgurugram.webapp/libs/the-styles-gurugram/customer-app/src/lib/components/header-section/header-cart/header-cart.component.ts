import { Component, Input, OnInit } from '@angular/core';
import { CartDetails } from '../../../models/cart-details';
import { AppConfig } from '@simaira-digital/the-styles-gurugram/shared';
import { CustomerAppSettings } from '../../../models/customer-app.settings.';

@Component({
  selector: 'simairadigital-customer-header-cart',
  templateUrl: './header-cart.component.html',
  styleUrls: ['./header-cart.component.scss'],
})
export class HeaderCartComponent implements OnInit {
  @Input() public settings: CustomerAppSettings;
  public subtotalTitle = 'subtotal';
  public viewCartTitle = 'view cart';
  public checkoutTitle = 'checkout';
  public cartDetails: CartDetails;
  public baseImageUrl = AppConfig.imageServerUrl;
  public constructor() {}

  public ngOnInit(): void {
    this.cartDetails = new CartDetails();
    this.cartDetails.items = [];
    this.cartDetails.items.push({
      name: 'Levis Jeans',
      image: `${this.baseImageUrl}/products/men/Jeans01.jpg`,
      price: 2999,
      quantity: 1,
    });
    this.cartDetails.items.push({
      name: 'Peter England Shirt',
      image: `${this.baseImageUrl}/products/men/Shirt01.jpg`,
      price: 1999,
      quantity: 1,
    });
    this.cartDetails.subtotal = '4998';
    this.cartDetails.totalItems = 2;
  }
}
