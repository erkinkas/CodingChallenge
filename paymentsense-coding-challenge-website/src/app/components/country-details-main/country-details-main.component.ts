import { Component, Input, OnInit } from '@angular/core';

import { CountryDetailsModel } from '../../models';

@Component({
  selector: 'app-country-details-main',
  templateUrl: './country-details-main.component.html',
  styleUrls: ['./country-details-main.component.scss']
})
export class CountryDetailsMainComponent implements OnInit {

  @Input()
  public country: CountryDetailsModel;

  constructor() { }

  ngOnInit() {
  }

}
