import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';

import { MaterialModule } from '../../material.module';

import { CountryDetailsModel, CountryCurrency } from '../../models';

import { CountryDetailsCurrenciesComponent } from './country-details-currencies.component';

describe('CountryDetailsCurrenciesComponent', () => {
  let component: CountryDetailsCurrenciesComponent;
  let fixture: ComponentFixture<CountryDetailsCurrenciesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        CountryDetailsCurrenciesComponent
      ],
      imports: [
        MaterialModule
      ]
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

  it('should not render', () => {
    component.country = null;

    fixture.detectChanges();
    const compiled = fixture.debugElement;

    let element = compiled.query(By.css('.nodata'));
    expect(element).toBeNull();

    element = compiled.query(By.css('.data'));
    expect(element).toBeNull();
  });

  it('should render "No currencies"', () => {
    component.country = <CountryDetailsModel>{
      currencies: null
    };

    fixture.detectChanges();

    const compiled = fixture.debugElement;
    const element = compiled.query(By.css('.nodata'));
    expect(element).not.toBeNull();
    expect(element.nativeElement.textContent).toContain('No currencies');
  });

  it('should render currencies N times', () => {
    const itemsCount: number = 2;

    let currencies: Array<CountryCurrency> = [];
    for (var index = 0; index < itemsCount; index++) {
      const currency = <CountryCurrency>{
        code: `code${index}`,
        name: `name${index}`,
        symbol: `symbol${index}`
      }
      currencies.push(currency);
    }

    component.country = <CountryDetailsModel>{
      currencies: currencies
    };

    fixture.detectChanges();
    const compiled = fixture.debugElement;

    const dataElement = compiled.query(By.css('.data'));
    expect(dataElement).not.toBeNull();

    const elements = compiled.queryAll(By.css('.data-item'));
    expect(elements).not.toBeNull();
    expect(elements.length).toBe(itemsCount);

    for (var index = 0; index < itemsCount; index++) {
      const element = elements[index].nativeElement;
      expect(element.textContent).toContain(`code${index}`);
      expect(element.textContent).toContain(`name${index}`);
      expect(element.textContent).toContain(`symbol${index}`);
    }
  });
});
