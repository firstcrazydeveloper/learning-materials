import { CartItem } from './cart-item';

export class CartDetails {
  public items: Array<CartItem>;
  public subtotal: string;
  public totalItems: number;
}
