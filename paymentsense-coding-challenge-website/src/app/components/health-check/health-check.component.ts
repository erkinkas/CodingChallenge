import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { faThumbsUp, faThumbsDown } from '@fortawesome/free-regular-svg-icons';

import { ApiHealthCheckService } from '../../services';

@Component({
  selector: 'app-health-check',
  templateUrl: './health-check.component.html',
  styleUrls: ['./health-check.component.scss']
})
export class HealthCheckComponent implements OnInit, OnDestroy {
  public apiActiveIcon;
  public apiActiveIconColour;

  private subscriptions: Array<Subscription> = [];

  constructor(private apiHealthCheckService: ApiHealthCheckService) {
    this.initApiActiveIcon(false);
  }

  ngOnInit() {
    this.subscriptions.push(
      this.apiHealthCheckService.isActive$
        .subscribe(
          isActive => {
            this.initApiActiveIcon(isActive);
          },
          _ => {
            this.initApiActiveIcon(false);
          })
    );
  }

  private initApiActiveIcon(isActive: boolean) {
    this.apiActiveIcon = isActive
      ? faThumbsUp
      : faThumbsDown;
    this.apiActiveIconColour = isActive
      ? 'green'
      : 'red';
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }
}
