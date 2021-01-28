import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryDetailsMainComponent } from './country-details-main.component';

describe('CountryDetailsMainComponent', () => {
  let component: CountryDetailsMainComponent;
  let fixture: ComponentFixture<CountryDetailsMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryDetailsMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryDetailsMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
