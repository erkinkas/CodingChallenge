import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';

import { CountryDetailsModel } from '../../models/';

@Injectable({
  providedIn: 'root'
})
export class CountryDetailsService {

  constructor(private httpClient: HttpClient) { }

  public Get(code: string): Observable<CountryDetailsModel> {
    return this.httpClient.get<CountryDetailsModel>(this.httpUrl(code), { responseType: 'json' });
  }

  private httpUrl(code: string): string {
    return `${environment.apiEndpoint}/country/${code}`;
  };
}
