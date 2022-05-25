import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { TheStylesGurugramSharedModule } from '@simaira-digital/the-styles-gurugram/shared';
import { LoaderComponent } from './components/loader/loader.component';
import { HeaderComponent } from './components/header-section/header/header.component';
import { HomeSliderComponent } from './components/slider-section/home-slider/home-slider.component';
import { CollectionBannerComponent } from './components/landing-contents/collection-banner/collection-banner.component';
import { ParallaxBannerComponent } from './components/landing-contents/parallax-banner/parallax-banner.component';
import { TabProductComponent } from './components/landing-contents/tab-product/tab-product.component';
import { BlogSectionComponent } from './components/blog-section/blog-section.component';
import { InstagramSectionComponent } from './components/instagram-section/instagram-section.component';
import { FooterLogoSectionComponent } from './components/footer-logo-section/footer-logo-section.component';
import { FooterSectionComponent } from './components/footer-section/footer-section.component';
import { TopHeaderComponent } from './components/header-section/top-header/top-header.component';
import { HeaderMenuComponent } from './components/header-section/header-menu/header-menu.component';
import { HeaderNavMenuComponent } from './components/header-section/header-nav-menu/header-nav-menu.component';
import { HeaderCartComponent } from './components/header-section/header-cart/header-cart.component';
import { HeaderSettingsComponent } from './components/header-section/header-settings/header-settings.component';
import { HeaderSearchComponent } from './components/header-section/header-search/header-search.component';
import { TopCollectionComponent } from './components/landing-contents/top-collection/top-collection.component';
import { ServiceComponent } from './components/landing-contents/service/service.component';
import { CustomerAppComponent } from './components/customer-app/customer-app.component';

@NgModule({
  imports: [CommonModule, TheStylesGurugramSharedModule],
  declarations: [
    LoaderComponent,
    HeaderComponent,
    HomeSliderComponent,
    CollectionBannerComponent,
    ParallaxBannerComponent,
    TabProductComponent,
    BlogSectionComponent,
    InstagramSectionComponent,
    FooterLogoSectionComponent,
    FooterSectionComponent,
    TopHeaderComponent,
    HeaderMenuComponent,
    HeaderNavMenuComponent,
    HeaderCartComponent,
    HeaderSettingsComponent,
    HeaderSearchComponent,
    TopCollectionComponent,
    ServiceComponent,
    CustomerAppComponent,
  ],
  exports: [
    LoaderComponent,
    HeaderComponent,
    HomeSliderComponent,
    CollectionBannerComponent,
    ParallaxBannerComponent,
    TabProductComponent,
    BlogSectionComponent,
    InstagramSectionComponent,
    FooterLogoSectionComponent,
    FooterSectionComponent,
    TopHeaderComponent,
    HeaderMenuComponent,
    HeaderNavMenuComponent,
    HeaderCartComponent,
    HeaderSettingsComponent,
    HeaderSearchComponent,
    TopCollectionComponent,
    ServiceComponent,
    CustomerAppComponent,
  ],
})
export class TheStylesGurugramCustomerAppModule {}
