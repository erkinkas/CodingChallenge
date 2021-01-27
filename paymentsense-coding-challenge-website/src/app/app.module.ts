import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ApiHealthCheckService } from './services';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { MaterialModule } from './material.module';

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
  providers: [ApiHealthCheckService],
  bootstrap: [AppComponent]
})
export class AppModule { }
