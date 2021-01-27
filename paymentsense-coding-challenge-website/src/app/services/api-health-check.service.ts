import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { take, map } from 'rxjs/operators';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiHealthCheckService {

  public isActive$: Observable<boolean>;

  constructor(private httpClient: HttpClient) {
    this.isActive$ = this.getHealth();
  }

  private getHealth(): Observable<boolean> {
    return this.httpClient.get(`${environment.apiEndpoint}/health`, { responseType: 'text' })
      .pipe(
        take(1),
        map(response => response === 'Healthy'));
  }
}
