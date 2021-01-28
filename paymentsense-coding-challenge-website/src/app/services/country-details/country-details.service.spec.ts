import { TestBed } from '@angular/core/testing';

import { defer } from 'rxjs';

import { HttpErrorResponse } from '@angular/common/http';

import { CountryDetailsService } from './country-details.service';

describe('CountryDetailsService', () => {
  let httpClientSpy: { get: jasmine.Spy };
  let service: CountryDetailsService;

  beforeEach(() => TestBed.configureTestingModule({}));

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);
    service = new CountryDetailsService(httpClientSpy as any);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return an error when the server returns a 404', () => {
    const errorResponse = new HttpErrorResponse({
      error: 'test 404 error',
      status: 404,
      statusText: 'Not Found'
    });

    httpClientSpy.get.and.returnValue(defer(() => Promise.reject(errorResponse)));

    service.Get("").subscribe(
      result => fail('expected an error, not result'),
      error => expect(error).toContain('Country is not found')
    );
  });
});
