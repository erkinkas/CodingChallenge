import { TestBed } from '@angular/core/testing';

import { CountryDetailsService } from './country-details.service';

describe('CountryDetailsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CountryDetailsService = TestBed.get(CountryDetailsService);
    expect(service).toBeTruthy();
  });
});
