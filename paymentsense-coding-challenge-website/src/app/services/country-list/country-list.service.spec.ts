import { TestBed } from '@angular/core/testing';

import { HttpClientTestingModule } from '@angular/common/http/testing';

import { CountryListService } from './country-list.service';

describe('CountryListService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      HttpClientTestingModule
    ]
  }));

  it('should be created', () => {
    const service: CountryListService = TestBed.get(CountryListService);
    expect(service).toBeTruthy();
  });
});
