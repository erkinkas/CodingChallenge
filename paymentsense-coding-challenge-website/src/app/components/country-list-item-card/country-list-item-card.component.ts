import { Component, OnInit, Input } from '@angular/core';

import { CountryListItemModel } from '../../models/country-list-item.model';

@Component({
  selector: 'app-country-list-item-card',
  templateUrl: './country-list-item-card.component.html',
  styleUrls: ['./country-list-item-card.component.scss']
})
export class CountryListItemCardComponent implements OnInit {
  @Input()
  country: CountryListItemModel;

  constructor() { }

  ngOnInit() {
  }

}
