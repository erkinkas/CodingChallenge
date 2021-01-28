import { Component, Input, OnInit } from '@angular/core';

import { CountryDetailsModel } from '../../models';

@Component({
  selector: 'app-country-details-languages',
  templateUrl: './country-details-languages.component.html',
  styleUrls: ['./country-details-languages.component.scss']
})
export class CountryDetailsLanguagesComponent implements OnInit {

  @Input()
  public country: CountryDetailsModel;

  constructor() { }

  ngOnInit() {
  }

}
