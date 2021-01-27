import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiHealthCheckService {
  constructor(private httpClient: HttpClient) { }

  public getHealth(): Observable<string> {
    return this.httpClient.get(`${environment.apiEndpoint}/health`, { responseType: 'text' });
  }
}
