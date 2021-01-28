import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { environment } from '../../../environments/environment';

import { CountryDetailsModel } from '../../models/';

@Injectable({
  providedIn: 'root'
})
export class CountryDetailsService {

  constructor(private httpClient: HttpClient) { }

  public Get(code: string): Observable<CountryDetailsModel> {
    return this.httpClient.get<CountryDetailsModel>(this.httpUrl(code), { responseType: 'json' })
      .pipe(catchError(this.handle404));
  }

  private httpUrl(code: string): string {
    return `${environment.apiEndpoint}/country/${code}`;
  };

  private handle404(error: HttpErrorResponse) {
    if (!(error.error instanceof ErrorEvent)) {
      if (error.status === 404) {
        return throwError('Country is not found.');
      }
    }
  }
}
