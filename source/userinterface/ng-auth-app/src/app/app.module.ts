import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MsalModule, MsalInterceptor } from '@azure/msal-angular';	

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AuthService } from './auth.service';

export const protectedResourceMap: [string, string[]][] = [
  ['https://graph.microsoft.com/v1.0/me', ['user.read']]
];


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    MsalModule.forRoot(
      {
        auth: {
          clientId: 'fb123f6b-5b23-447a-835d-aea96bdac353', // This is your client ID
          authority: 'https://login.microsoftonline.com/09abbc86-84ed-4481-83a3-4dc0f095d0b9', // This is your tenant ID
          redirectUri: 'http://localhost:4200/',  // This is your redirect URI
          postLogoutRedirectUri: "https://localhost:4200/",
          navigateToLoginRequestUrl: true,
        },
        cache: {
          cacheLocation: 'localStorage',
          storeAuthStateInCookie: false, // Set to true for Internet Explorer 11
        },
      },
      {
        popUp: false,
        consentScopes: [
          "user.read",
          "openid",
          "profile"
        ],
        unprotectedResources: ["https://www.microsoft.com/en-us/"],
        protectedResourceMap:[
          ['https://graph.microsoft.com/v1.0/me', ['user.read']]
        ],
        extraQueryParameters: {}
      }
    ),
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    },
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
