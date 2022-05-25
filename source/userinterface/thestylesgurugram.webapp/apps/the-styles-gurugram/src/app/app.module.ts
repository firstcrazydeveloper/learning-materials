import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { TheStylesGurugramCustomerAppModule } from '@simaira-digital/the-styles-gurugram/customer-app';
import { AppConfigService } from '@simaira-digital/the-styles-gurugram/shared';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

const appInitializerFn = (appConfig: AppConfigService) => {
  return () => {
      const promises: Promise<void | {}>[] = [];
      promises.push(appConfig.loadAppConfig());
      return Promise.all(promises).then(() => {
      });
  };
};
@NgModule({
  declarations: [AppComponent, HomeComponent],
  imports: [BrowserModule, CommonModule, HttpClientModule, TheStylesGurugramCustomerAppModule],
  providers: [ AppConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializerFn,
      deps: [AppConfigService],
      multi: true
  }
 ],
  bootstrap: [HomeComponent],
})
export class AppModule {}
