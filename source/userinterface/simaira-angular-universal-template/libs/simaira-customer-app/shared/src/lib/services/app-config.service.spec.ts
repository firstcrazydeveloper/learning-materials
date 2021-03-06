import { AppConfigService } from './app-config.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { inject, TestBed } from '@angular/core/testing';

describe('AppConfigService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [AppConfigService],
    });
  });

  it('should be created', inject(
    [AppConfigService],
    (service: AppConfigService) => {
      expect(service).toBeTruthy();
    }
  ));
});
