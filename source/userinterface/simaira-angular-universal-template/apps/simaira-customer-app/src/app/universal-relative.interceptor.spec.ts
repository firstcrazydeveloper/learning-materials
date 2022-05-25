import {
  HttpClient,
  HttpClientModule,
  HTTP_INTERCEPTORS,
} from '@angular/common/http';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { inject, TestBed } from '@angular/core/testing';
import { REQUEST } from '@nguniversal/express-engine/tokens';
import { Request } from 'express';
import { UniversalRelativeInterceptor } from './universal-relative.interceptor';

const CONSTANTS = {
  protocol: 'testProtocol',
  host: 'testHost',
};

const configureTestModule = (request: Request) => {
  TestBed.configureTestingModule({
    imports: [HttpClientModule, HttpClientTestingModule],
    providers: [
      {
        provide: HTTP_INTERCEPTORS,
        useClass: UniversalRelativeInterceptor,
        multi: true,
      },
      {
        provide: REQUEST,
        useValue: request,
      },
    ],
  });
};

describe(`UniversalRelativeInterceptor`, () => {
  describe('absolute and protocol-relative url', () => {
    beforeEach(() => {
      configureTestModule({} as Request);
    });

    // Using 'inject' as opposed to creating a mock service with a HttpClient
    it('should not change absolute or protocol-relative url', inject(
      [HttpClient],
      (httpClient: HttpClient) => {
        // The SSR Interceptor uses express.js Request, with token REQUEST
        const httpMock = TestBed.get(
          HttpTestingController
        ) as HttpTestingController;

        const httpURL = 'http://test.com/api/users';
        httpClient.get(httpURL).subscribe();
        httpMock.expectOne(httpURL);

        const secureURL = 'https://test.com/api/users';
        httpClient.get(secureURL).subscribe();
        httpMock.expectOne(secureURL);

        const protocolRelativeURL = '//test.com/api/users';
        httpClient.get(protocolRelativeURL).subscribe();
        httpMock.expectOne(protocolRelativeURL);
      }
    ));
  });

  describe('relative url', () => {
    beforeEach(() => {
      const request = {
        protocol: CONSTANTS.protocol,
        get(name: string) {
          return name === 'host' ? CONSTANTS.host : '';
        },
      } as Request;
      configureTestModule(request);
    });

    it('should update relative URL to absolute', inject(
      [HttpClient],
      (httpClient: HttpClient) => {
        const httpMock = TestBed.get(
          HttpTestingController
        ) as HttpTestingController;

        const relative_1 = 'api/users';
        httpClient.get(relative_1).subscribe();
        const absolute_1 = `${CONSTANTS.protocol}://${CONSTANTS.host}/${relative_1}`;
        httpMock.expectOne(absolute_1);

        const relative_2 = '/api/accounts';
        httpClient.get(relative_2).subscribe();
        const absolute_2 = `${CONSTANTS.protocol}://${CONSTANTS.host}${relative_2}`;
        httpMock.expectOne(absolute_2);
      }
    ));
  });
});
