import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialModule } from './material.module';

import { ApiHealthCheckService, CountryListService, CountryDetailsService } from './services';

import { AppComponent } from './app.component';

import { HealthCheckComponent } from './components/health-check/health-check.component';
import { HeaderComponent } from './components/header/header.component';

import { CountryListComponent } from './components/country-list/country-list.component';
import { CountryListItemCardComponent } from './components/country-list-item-card/country-list-item-card.component';

import { CountryDetailsComponent } from './components/country-details/country-details.component';
import { CountryDetailsMainComponent } from './components/country-details-main/country-details-main.component';
import { CountryDetailsCurrenciesComponent } from './components/country-details-currencies/country-details-currencies.component';
import { CountryDetailsLanguagesComponent } from './components/country-details-languages/country-details-languages.component';

import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
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
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,

    MaterialModule
  ],
  providers: [
    ApiHealthCheckService,
    CountryListService,
    CountryDetailsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
