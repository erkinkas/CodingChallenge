import { NgModule } from '@angular/core';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { HealthCheckComponent } from './health-check/health-check.component';
import { HeaderComponent } from './header/header.component';
import { CountryListComponent } from './country-list/country-list.component';
import { CountryListItemCardComponent } from './country-list-item-card/country-list-item-card.component';
import { CountryDetailsComponent } from './country-details/country-details.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CountryDetailsMainComponent } from './country-details-main/country-details-main.component';
import { CountryDetailsCurrenciesComponent } from './country-details-currencies/country-details-currencies.component';
import { CountryDetailsLanguagesComponent } from './country-details-languages/country-details-languages.component';

@NgModule({
  declarations: [
    HealthCheckComponent,
    HeaderComponent,
    CountryListComponent,
    CountryListItemCardComponent,
    CountryDetailsComponent,
    PageNotFoundComponent,
    CountryDetailsMainComponent,
    CountryDetailsCurrenciesComponent,
    CountryDetailsLanguagesComponent
  ],
  imports: [
    FontAwesomeModule
  ],
})
export class ComponentsModule { }
