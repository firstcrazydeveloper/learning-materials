import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthConfig } from 'angular-oauth2-oidc';
import { AppConfig } from '../app.config';

@Injectable()
export class AppConfigService {
    private appConfig;

    public constructor(private http: HttpClient) {}

    public loadAppConfig() {
        return this.http
            .get(`/assets/appConfig.json`)
            .toPromise()
            .then(environmentConfig => {
                Object.assign(AppConfig, environmentConfig);
                const authConfig = new AuthConfig();
                Object.assign(authConfig, environmentConfig['authParams']);
                AppConfig.authConfig = authConfig;
                this.appConfig = environmentConfig;
            });
    }

    public featureIsEnabled(feature: string): boolean {
        const { features } = this.appConfig;
        if (!features) {
            return false;
        }

        if (features['*']) {
            return true;
        }

        return features[feature];
    }
}
