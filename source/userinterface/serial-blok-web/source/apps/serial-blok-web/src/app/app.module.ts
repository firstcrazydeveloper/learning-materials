import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {
  MsalBroadcastService,
  MsalGuard,
  MsalGuardConfiguration,
  MsalInterceptor,
  MsalInterceptorConfiguration,
  MsalModule,
  MsalService,
  MSAL_GUARD_CONFIG,
  MSAL_INSTANCE,
  MSAL_INTERCEPTOR_CONFIG,
} from '@azure/msal-angular';
import {
  BrowserCacheLocation,
  InteractionType,
  IPublicClientApplication,
  PublicClientApplication,
} from '@azure/msal-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationService } from './authentication.service';
import { CalculatorComponent } from './calculator/calculator.component';
import { HomeComponent } from './home/home.component';

const isIE =
  window.navigator.userAgent.indexOf('MSIE ') > -1 ||
  window.navigator.userAgent.indexOf('Trident/') > -1;

const msalInstanceFactory: () => IPublicClientApplication = () => {
  return new PublicClientApplication({
    auth: {
      clientId: 'fb123f6b-5b23-447a-835d-aea96bdac353',
      authority:
        'https://login.microsoftonline.com/09abbc86-84ed-4481-83a3-4dc0f095d0b9',
      redirectUri: 'https://localhost:4200/',
      postLogoutRedirectUri: 'https://simairadigital.com',
      navigateToLoginRequestUrl: true,
    },
    cache: {
      cacheLocation: BrowserCacheLocation.LocalStorage,
      storeAuthStateInCookie: isIE, // According to msal-browser sample: https://github.com/AzureAD/microsoft-authentication-library-for-js
    },
  });
};

const msalInterceptorConfigFactory: () => MsalInterceptorConfiguration = () => {
  return {
    interactionType: InteractionType.Redirect,
    protectedResourceMap: new Map([
      [
        'https://graph.microsoft.com/v1.0/me',
        [
          'api://fb123f6b-5b23-447a-835d-aea96bdac353/simaira_backend_productmanagement_user',
        ],
      ],
    ]),
  };
};

const msalGuardConfig: () => MsalGuardConfiguration = () => {
  return {
    interactionType: InteractionType.Redirect,
  };
};
@NgModule({
  declarations: [AppComponent, HomeComponent, CalculatorComponent],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    MsalModule,
  ],
  providers: [
    MsalService,
    AuthenticationService,
    {
      provide: MSAL_INSTANCE,
      useFactory: msalInstanceFactory,
    },
    {
      provide: MSAL_INTERCEPTOR_CONFIG,
      useFactory: msalInterceptorConfigFactory,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true,
    },
    {
      provide: MSAL_GUARD_CONFIG,
      useFactory: msalGuardConfig,
    },
    MsalGuard,
    MsalBroadcastService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
