import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryDetailsLanguagesComponent } from './country-details-languages.component';

describe('CountryDetailsLanguagesComponent', () => {
  let component: CountryDetailsLanguagesComponent;
  let fixture: ComponentFixture<CountryDetailsLanguagesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryDetailsLanguagesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryDetailsLanguagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
