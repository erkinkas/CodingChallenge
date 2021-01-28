import { Component, Input, OnInit } from '@angular/core';

import { CountryDetailsModel } from '../../models';

@Component({
  selector: 'app-country-details-currencies',
  templateUrl: './country-details-currencies.component.html',
  styleUrls: ['./country-details-currencies.component.scss']
})
export class CountryDetailsCurrenciesComponent implements OnInit {

  @Input()
  public country: CountryDetailsModel;

  constructor() { }

  ngOnInit() {
  }

}
