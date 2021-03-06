import { Component, OnInit, Input } from '@angular/core';

import { Router } from '@angular/router';

import { CountryListItemModel } from '../../models';

@Component({
  selector: 'app-country-list-item-card',
  templateUrl: './country-list-item-card.component.html',
  styleUrls: ['./country-list-item-card.component.scss']
})
export class CountryListItemCardComponent implements OnInit {
  @Input() country: CountryListItemModel;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  public clicked() {
    this.router.navigate([`details/${this.country.alpha3Code}`]);
  }

}
