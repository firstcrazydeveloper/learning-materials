import { Injectable } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import {
  AccountInfo,
  AuthenticationResult,
  EndSessionRequest,
  RedirectRequest,
  SsoSilentRequest,
} from '@azure/msal-browser';
import { BehaviorSubject, Observable } from 'rxjs';
export enum AuthenticationState {
  Initializing,
  LoggedOut,
  SilentLogin,
  LoggedIn,
}
import { User } from './user';

@Injectable()
export class AuthenticationService {
  private authResult: AuthenticationResult;

  private readonly currentUserChangedSubject: BehaviorSubject<User> = new BehaviorSubject<User>(
    null
  );
  public readonly currentUserChanged: Observable<User> = this.currentUserChangedSubject.asObservable();

  private readonly authStateSubject: BehaviorSubject<AuthenticationState> = new BehaviorSubject<AuthenticationState>(
    AuthenticationState.Initializing
  );
  public readonly authState: Observable<AuthenticationState> = this.authStateSubject.asObservable();

  public constructor(private msalService: MsalService) {}

  private getLoggedInAccount(): AccountInfo {
    const accounts = this.msalService.instance.getAllAccounts();
    if (accounts?.length === 1) {
      return accounts[0];
    } else {
      return null;
    }
  }

  private get isGoodbyeRoute(): boolean {
    return location.pathname.indexOf('goodbye') >= 0;
  }

  private trySilentLogin() {
    // Avoid automatic login to be triggered on logout-route
    if (this.isGoodbyeRoute) {
      this.authStateSubject.next(AuthenticationState.LoggedOut);
      return;
    }

    // When account-information is available in local storage - try to login
    const account = this.getLoggedInAccount();
    if (account) {
      this.authStateSubject.next(AuthenticationState.SilentLogin);
      const silentRequest: SsoSilentRequest = {
        loginHint: account.username,
      };
      this.msalService.ssoSilent(silentRequest).subscribe({
        next: (result: AuthenticationResult) => {
          // Everything fine - User has been logged in automatically
          this.onLoginSuccess(result);
        },
        error: (error) => {
          // Something failed - redirect to AAD login
          this.onAutoLoginFailed();
        },
      });
    } else {
      // If there is no account-information available redirect to AAD login
      this.login();
    }
  }

  public initializeAuthentication() {
    this.msalService.handleRedirectObservable().subscribe({
      next: (result: AuthenticationResult) => {
        if (result) {
          console.log('Authenticate success');
          console.log(result);
          this.onLoginSuccess(result);
        } else {
          this.trySilentLogin();
        }
      },
      error: (error) => {
        console.log('Authenticate Failed');
        console.log(error);
        this.authStateSubject.next(AuthenticationState.LoggedOut);
      },
    });
  }

  public login() {
    // Make sure to redirect to '/' after login when triggering the login-request from logout-route
    const request: RedirectRequest = {
      scopes: [],
      redirectUri: '/',
      redirectStartPage: this.isGoodbyeRoute
        ? '/'
        : `${location.pathname}${location.search}`,
    };
    this.msalService.loginRedirect(request).subscribe();
  }

  private onLoginSuccess(result: AuthenticationResult) {
    this.authResult = result;
    this.msalService.instance.setActiveAccount(result.account);
    console.log('user details');
    console.log(result);
    const user = new User();
    user.oid = result.account.localAccountId;
    user.emailAddress = result.account.username;
    user.name = result.account.name;

    this.currentUserChangedSubject.next(user);
    this.authStateSubject.next(AuthenticationState.LoggedIn);
  }

  private onAutoLoginFailed() {
    this.authStateSubject.next(AuthenticationState.LoggedOut);
    this.login();
  }

  public logout() {
    const account = this.getLoggedInAccount();
    const logoutRequest: EndSessionRequest = { account };
    this.msalService
      .logout(logoutRequest)
      .subscribe(() =>
        this.authStateSubject.next(AuthenticationState.LoggedOut)
      );
  }

  public hasValidToken() {
    return !!this.authResult?.accessToken;
  }

  // These normally won't be exposed from a service like this, but
  // for debugging it makes sense.
  public get accessToken() {
    return this.authResult?.accessToken;
  }
  public get identityClaims() {
    return this.authResult?.idTokenClaims;
  }
  public get idToken() {
    return this.authResult?.idToken;
  }

  // Additional (not really) auth things
  public get currentUser(): User {
    const user: User = this.currentUserChangedSubject.getValue();
    if (!user) {
      return undefined;
    }

    return user;
  }
}
