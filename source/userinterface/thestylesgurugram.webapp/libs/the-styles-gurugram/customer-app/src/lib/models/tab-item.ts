import { Item } from './item';

export class TabItem {
  public name: string;
  public id: string;
  public isActive: boolean;
  public items: Array<Item>;
}
