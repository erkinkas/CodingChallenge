import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { take } from 'rxjs/operators';

import { faThumbsUp, faThumbsDown } from '@fortawesome/free-regular-svg-icons';

import { PaymentsenseCodingChallengeApiService } from '../../services';

@Component({
  selector: 'app-health-check',
  templateUrl: './health-check.component.html',
  styleUrls: ['./health-check.component.scss']
})
export class HealthCheckComponent implements OnInit, OnDestroy {
  public faThumbsUp = faThumbsUp;
  public faThumbsDown = faThumbsDown;
  public title = 'Paymentsense Coding Challenge!';
  public paymentsenseCodingChallengeApiIsActive = false;
  public paymentsenseCodingChallengeApiActiveIcon = this.faThumbsDown;
  public paymentsenseCodingChallengeApiActiveIconColour = 'red';

  private subscriptions: Array<Subscription> = [];

  constructor(private paymentsenseCodingChallengeApiService: PaymentsenseCodingChallengeApiService) { }

  ngOnInit() {
    this.subscriptions.push(
      this.paymentsenseCodingChallengeApiService.getHealth()
        .pipe(take(1))
        .subscribe(
          apiHealth => {
            this.paymentsenseCodingChallengeApiIsActive = apiHealth === 'Healthy';
            this.paymentsenseCodingChallengeApiActiveIcon = this.paymentsenseCodingChallengeApiIsActive
              ? this.faThumbsUp
              : this.faThumbsUp;
            this.paymentsenseCodingChallengeApiActiveIconColour = this.paymentsenseCodingChallengeApiIsActive
              ? 'green'
              : 'red';
          },
          _ => {
            this.paymentsenseCodingChallengeApiIsActive = false;
            this.paymentsenseCodingChallengeApiActiveIcon = this.faThumbsDown;
            this.paymentsenseCodingChallengeApiActiveIconColour = 'red';
          })
    );
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }
}
