import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryListItemCardComponent } from './country-list-item-card.component';

describe('CountryListItemCardComponent', () => {
  let component: CountryListItemCardComponent;
  let fixture: ComponentFixture<CountryListItemCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CountryListItemCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryListItemCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
