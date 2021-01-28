import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Component, Input } from '@angular/core';

import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { MaterialModule } from '../../material.module';

import { CountryDetailsModel } from '../../models';

import { CountryDetailsComponent } from './country-details.component';

@Component({ selector: 'app-country-details-main', template: '' })
class MockMainComponent {
  @Input() country: CountryDetailsModel
}

@Component({ selector: 'app-country-details-currencies', template: '' })
class MockCurrenciesComponent {
  @Input() country: CountryDetailsModel
}

@Component({ selector: 'app-country-details-languages', template: '' })
class MockLanguagesComponent {
  @Input() country: CountryDetailsModel
}

describe('CountryDetailsComponent', () => {
  let component: CountryDetailsComponent;
  let fixture: ComponentFixture<CountryDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        CountryDetailsComponent,
        MockMainComponent,
        MockCurrenciesComponent,
        MockLanguagesComponent
      ],
      imports: [
        MaterialModule,
        HttpClientTestingModule,
        RouterTestingModule
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
