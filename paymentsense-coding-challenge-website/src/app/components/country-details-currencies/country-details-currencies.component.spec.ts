import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryDetailsCurrenciesComponent } from './country-details-currencies.component';

describe('CountryDetailsCurrenciesComponent', () => {
  let component: CountryDetailsCurrenciesComponent;
  let fixture: ComponentFixture<CountryDetailsCurrenciesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryDetailsCurrenciesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryDetailsCurrenciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
