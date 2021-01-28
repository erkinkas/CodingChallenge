import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';

import { PagedResponse, CountryListItemModel } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class CountryListService {

  constructor(private httpClient: HttpClient) { }

  public Get(pageIndex: number, pageSize: number): Observable<PagedResponse<CountryListItemModel>> {
    return this.httpClient.get<PagedResponse<CountryListItemModel>>(this.httpUrl(pageIndex, pageSize), { responseType: 'json' });
  }

  private httpUrl(pageIndex: number, pageSize: number): string {
    return `${environment.apiEndpoint}/country?pageIndex=${pageIndex}&pageLimit=${pageSize}`;
  };
}
