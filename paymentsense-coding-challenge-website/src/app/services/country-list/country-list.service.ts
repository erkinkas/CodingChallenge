import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';

import { CountryListItemModel } from '../../models/country-list-item.model';
import { PagedResponse } from '../../models/paged-response';

@Injectable({
  providedIn: 'root'
})
export class CountryListService {

  constructor(private httpClient: HttpClient) { }

  public Get(pageIndex: number, pageSize: number): Observable<PagedResponse<CountryListItemModel>> {
    return this.httpClient.get<PagedResponse<CountryListItemModel>>(`${environment.apiEndpoint}/country?pageIndex=${pageIndex}&pageLimit=${pageSize}`, { responseType: 'json' });
  }
}
