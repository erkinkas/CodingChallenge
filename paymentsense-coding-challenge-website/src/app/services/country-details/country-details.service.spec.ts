import { TestBed } from '@angular/core/testing';

import { HttpClientTestingModule } from '@angular/common/http/testing';

import { CountryDetailsService } from './country-details.service';

describe('CountryDetailsService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      HttpClientTestingModule
    ]
  }));

  it('should be created', () => {
    const service: CountryDetailsService = TestBed.get(CountryDetailsService);
    expect(service).toBeTruthy();
  });
});
