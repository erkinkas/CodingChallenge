import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs';

import { CountryDetailsModel } from '../../models';

import { CountryDetailsService } from '../../services';

@Component({
  selector: 'app-country-details',
  templateUrl: './country-details.component.html',
  styleUrls: ['./country-details.component.scss']
})
export class CountryDetailsComponent implements OnInit, OnDestroy {

  public country: CountryDetailsModel;

  private subscriptions: Array<Subscription> = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private countryDetailsService: CountryDetailsService
  ) { }

  ngOnInit() {
    const code = this.route.snapshot.paramMap.get('code');
    this.subscriptions.push(
      this.countryDetailsService.Get(code)
        .subscribe(cd => {
          this.country = cd;
        },
          (error) => {
            this.country = null;
            console.log(`country code "${code}" returned "${error}". Redirecting to the main page...`);
            this.router.navigate([`countries`]);
          })
    );
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

}
