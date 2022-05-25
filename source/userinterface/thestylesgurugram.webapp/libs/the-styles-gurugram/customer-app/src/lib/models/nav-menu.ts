import { Menu } from './menu';

export class NavMenu {
  public name: string;
  public menus: Array<Menu>;
  public url: string;
  public isNew: boolean;
  public isChild: boolean;
}
