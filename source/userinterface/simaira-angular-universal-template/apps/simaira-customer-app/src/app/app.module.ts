import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { SimairaCustomerAppHomeModule } from '@simaira/simaira-customer-app/home';
import { AppConfigService } from '@simaira/simaira-customer-app/shared';
import { AppComponent } from './app.component';
import { I18nModule } from './i18n/i18n.module';
import { SelectLanguageComponent } from './select-language/select-language.component';

const appInitializerFn = (appConfig: AppConfigService) => {
  return () => {
    const promises: Promise<void | {}>[] = [];
    promises.push(appConfig.loadAppConfig());
    return Promise.all(promises).then(() => {});
  };
};

@NgModule({
  declarations: [AppComponent, SelectLanguageComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    CommonModule,
    HttpClientModule,
    SimairaCustomerAppHomeModule,
    I18nModule,
  ],
  providers: [
    AppConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializerFn,
      deps: [AppConfigService],
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
