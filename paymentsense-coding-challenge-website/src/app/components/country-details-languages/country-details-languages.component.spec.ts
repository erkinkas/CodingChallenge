import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';

import { MaterialModule } from '../../material.module';

import { CountryDetailsModel, CountryLanguage } from '../../models';

import { CountryDetailsLanguagesComponent } from './country-details-languages.component';

describe('CountryDetailsLanguagesComponent', () => {
  let component: CountryDetailsLanguagesComponent;
  let fixture: ComponentFixture<CountryDetailsLanguagesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        CountryDetailsLanguagesComponent
      ],
      imports: [
        MaterialModule
      ]
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

  it('should not render', () => {
    component.country = null;

    fixture.detectChanges();
    const compiled = fixture.debugElement;

    let element = compiled.query(By.css('.nodata'));
    expect(element).toBeNull();

    element = compiled.query(By.css('.data'));
    expect(element).toBeNull();
  });

  it('should render "No languages"', () => {
    component.country = <CountryDetailsModel>{
      languages: null
    };

    fixture.detectChanges();

    const compiled = fixture.debugElement;
    const element = compiled.query(By.css('.nodata'));
    expect(element).not.toBeNull();
    expect(element.nativeElement.textContent).toContain('No languages');
  });

  it('should render languages N times', () => {
    const itemsCount: number = 2;

    let items: Array<CountryLanguage> = [];
    for (var index = 0; index < itemsCount; index++) {
      const item = <CountryLanguage>{
        iso639_1: `iso639_1${index}`,
        iso639_2: `iso639_2${index}`,
        name: `name${index}`,
        nativeName: `nativeName${index}`
      }
      items.push(item);
    }

    component.country = <CountryDetailsModel>{
      languages: items
    };

    fixture.detectChanges();

    const compiled = fixture.debugElement;

    var dataElement = compiled.query(By.css('.data'));
    expect(dataElement).not.toBeNull();

    for (var index = 0; index < itemsCount; index++) {
      const element = dataElement.nativeElement;
      expect(element.textContent).toContain(`iso639_1${index}`);
      expect(element.textContent).toContain(`iso639_2${index}`);
      expect(element.textContent).toContain(`name${index}`);
      expect(element.textContent).toContain(`nativeName${index}`);
    }
  });
});
