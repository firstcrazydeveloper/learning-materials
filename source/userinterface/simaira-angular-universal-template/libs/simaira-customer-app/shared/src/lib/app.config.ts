import { EnvironmentConfig } from './environment.config';

declare let require: any;

export interface ILanguage {
    language: string;
    country: string;
    countryCodeFlag: string;
    nativeName: string;
    hour12Format: boolean;
}

export interface IAppModule {
    textKey: string;
    icon: string;
    requiredRoles: string[];
}

export interface IApp {
    textKey: string;
    icon: string;
    requiredRoles: string[];
    appModules: IAppModule[];
}

export interface IAppModuleChunk {
    app: IApp;
    appModule: IAppModule;
}

export enum ILegalPageType {
    Disclaimer,
    Privacy,
    Imprint,
    TermsAndConditions
}

export interface ILegalPage {
    textKey: string;
    type: ILegalPageType;
}

export const infinitePageSize = 999999999;
export const defaultPageSize = 25;
export const optionsKeyAll = '%all%';

export class AppConfig extends EnvironmentConfig {
    public static version = require('../../../../../package.json').version; // NOSONAR

    public static languages: ILanguage[] = [
        {
            language: 'en',
            country: 'GB',
            countryCodeFlag: 'gb',
            nativeName: 'English (GB)',
            hour12Format: false
        },
        {
            language: 'en',
            country: 'US',
            countryCodeFlag: 'us',
            nativeName: 'English (US)',
            hour12Format: true
        },
        {
            language: 'de',
            country: 'DE',
            countryCodeFlag: 'de',
            nativeName: 'Deutsch',
            hour12Format: false
        }
    ];

    public static customTranslations: ILanguage[] = [
        {
            language: 'en_yms',
            country: 'GB',
            countryCodeFlag: 'gb',
            nativeName: 'English (GB)',
            hour12Format: false
        },
        {
            language: 'en_yms',
            country: 'US',
            countryCodeFlag: 'us',
            nativeName: 'English (US)',
            hour12Format: true
        },
        {
            language: 'de_yms',
            country: 'DE',
            countryCodeFlag: 'de',
            nativeName: 'Deutsch',
            hour12Format: false
        }
    ];
}
