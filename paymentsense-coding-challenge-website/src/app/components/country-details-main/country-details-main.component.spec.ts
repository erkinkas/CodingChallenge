import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';

import { MaterialModule } from '../../material.module';

import { CountryDetailsModel } from '../../models';

import { CountryDetailsMainComponent } from './country-details-main.component';

describe('CountryDetailsMainComponent', () => {
  let component: CountryDetailsMainComponent;
  let fixture: ComponentFixture<CountryDetailsMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        CountryDetailsMainComponent
      ],
      imports: [
        MaterialModule
      ]
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

  it('should not render', () => {
    component.country = null;

    fixture.detectChanges();
    const compiled = fixture.debugElement;

    let element = compiled.query(By.css('.content'));
    expect(element).toBeNull();
  });

  it('should render', () => {
    const model: CountryDetailsModel = <CountryDetailsModel>{
      population: 123,
      capitalCity: "city Capital",
      timezones: null,
      borderingCountries: null
    }
    component.country = model;

    fixture.detectChanges();

    const compiled = fixture.debugElement;
    const element = compiled.query(By.css('.content'));
    expect(element).not.toBeNull();

    expect(element.nativeElement.textContent).toContain(model.population);
    expect(element.nativeElement.textContent).toContain(model.capitalCity);
    expect(element.nativeElement.textContent).toContain("No timezones");
    expect(element.nativeElement.textContent).toContain("No bordering countries");
  });

  it('should render timezones N times', () => {
    const itemsCount: number = 2;

    let items: Array<string> = [];
    for (var index = 0; index < itemsCount; index++) {
      const item = `timezone${index}`;
      items.push(item);
    }

    component.country = <CountryDetailsModel>{
      timezones: items
    };

    fixture.detectChanges();

    const compiled = fixture.debugElement;

    var dataElement = compiled.query(By.css('.content'));
    expect(dataElement).not.toBeNull();

    for (var index = 0; index < itemsCount; index++) {
      const element = dataElement.nativeElement;
      expect(element.textContent).toContain(`timezone${index}`);
    }
  });

  it('should render borderingCountries N times', () => {
    const itemsCount: number = 2;

    let items: Array<string> = [];
    for (var index = 0; index < itemsCount; index++) {
      const item = `borderingCountry${index}`;
      items.push(item);
    }

    component.country = <CountryDetailsModel>{
      borderingCountries: items
    };

    fixture.detectChanges();

    const compiled = fixture.debugElement;

    var dataElement = compiled.query(By.css('.content'));
    expect(dataElement).not.toBeNull();

    for (var index = 0; index < itemsCount; index++) {
      const element = dataElement.nativeElement;
      expect(element.textContent).toContain(`borderingCountry${index}`);
    }
  });
});
