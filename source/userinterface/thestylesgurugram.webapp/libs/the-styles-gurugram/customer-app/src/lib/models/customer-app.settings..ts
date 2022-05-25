import { CollectionBanner } from './collection-banner';
import { CustomerSettings } from './customer-settings';
import { HeaderMenuSetting } from './header-menu-setting';
import { HomeSliderSettings } from './home-slider.settings';
import { ParallaxBanner } from './parallax-banner';
import { Service } from './service';
import { TabProduct } from './tab-product.settings';
import { TopCollection } from './top-collection.settings';
import { TopHeaderSettings } from './top-header.settings';

export class CustomerAppSettings {
  public service: Service;
  public headerMenuSetting: HeaderMenuSetting;
  public collectionBanners: Array<CollectionBanner>;
  public topCollection: TopCollection;
  public parallaxBanner: ParallaxBanner;
  public tabProduct: TabProduct;
  public topHeader: TopHeaderSettings;
  public customerSettings: CustomerSettings;
  public homeSliderSettings: HomeSliderSettings;
}
