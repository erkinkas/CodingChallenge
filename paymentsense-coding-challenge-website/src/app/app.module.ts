import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialModule } from './material.module';

import { ApiHealthCheckService, CountryListService } from './services';

import { AppComponent } from './app.component';

import { HealthCheckComponent } from './components/health-check/health-check.component';
import { HeaderComponent } from './components/header/header.component';
import { CountryListComponent } from './components/country-list/country-list.component';
import { CountryListItemCardComponent } from './components/country-list-item-card/country-list-item-card.component';

@NgModule({
  declarations: [
    AppComponent,
    HealthCheckComponent,
    HeaderComponent,
    CountryListComponent,
    CountryListItemCardComponent
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
    CountryListService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
