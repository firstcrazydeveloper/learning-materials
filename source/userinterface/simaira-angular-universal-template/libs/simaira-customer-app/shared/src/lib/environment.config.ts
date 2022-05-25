import { AuthConfig } from 'angular-oauth2-oidc';
import { FeatureFlags } from './models/feature.flags';

export class EnvironmentConfig {
    // Note that the name of these properties have to be exactly the same as the names of the properties in features inside appConfig.json

    public static useUserSettingsCache = true;
    public static environmentName: string;

    // image urls
    public static imageServerUrl: string;

    // Authentication configuration
    public static authConfig: AuthConfig;

    // Application Insights
    public static appInsightsInstrumentationKey: string;

    // Feature flag conigs
    public static features: FeatureFlags;
}
