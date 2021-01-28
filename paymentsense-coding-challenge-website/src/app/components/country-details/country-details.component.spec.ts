import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Component, Input } from '@angular/core';

import { Observable, of } from 'rxjs';

import { ActivatedRoute, convertToParamMap, Router } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from '../../material.module';

import { CountryDetailsModel } from '../../models';
import { CountryDetailsService } from '../../services';

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

class MockCountryDetailsService {
  public Get(code: string): Observable<CountryDetailsModel> {
    return of(null);
  }
}

describe('CountryDetailsComponent', () => {
  let component: CountryDetailsComponent;
  let fixture: ComponentFixture<CountryDetailsComponent>;

  let countryCode: 'country code';
  let routerSpy = {
    navigate: jasmine.createSpy('navigate')
  }

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
        BrowserAnimationsModule
      ],
      providers: [
        { provide: CountryDetailsService, useClass: MockCountryDetailsService },
        {
          provide: ActivatedRoute, useValue: {
            snapshot: {
              paramMap: convertToParamMap({ 'code': countryCode })
            }
          }
        },
        { provide: Router, useValue: routerSpy }
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

  it('should bind country', () => {
    const model = new CountryDetailsModel();

    const actionMeasuresService = TestBed.get(CountryDetailsService) as CountryDetailsService;
    spyOn(actionMeasuresService, 'Get')
      .and.returnValue(of(model));

    component.ngOnInit();

    fixture.detectChanges();

    expect(component.country).toBe(model);
  });

  it('should not bind country if error thrown', () => {
    const actionMeasuresService = TestBed.get(CountryDetailsService) as CountryDetailsService;
    spyOn(actionMeasuresService, 'Get')
      .and.returnValue(new Observable(observer => {
        observer.error(new Error("test exception"))
        observer.complete();
      }));

    component.ngOnInit();

    fixture.detectChanges();

    expect(component.country).toBe(null);
  });

  it('should redirect if error thrown', () => {
    const actionMeasuresService = TestBed.get(CountryDetailsService) as CountryDetailsService;
    spyOn(actionMeasuresService, 'Get')
      .and.returnValue(new Observable(observer => {
        observer.error(new Error("test exception"))
        observer.complete();
      }));

    component.ngOnInit();

    fixture.detectChanges();

    fixture.whenStable().then(() => {
      expect(routerSpy.navigate).toHaveBeenCalledWith(['countries']);
    });
  });

  it('should call service with code from route', () => {
    const actionMeasuresService = TestBed.get(CountryDetailsService) as CountryDetailsService;
    spyOn(actionMeasuresService, 'Get')
      .and.returnValue(of(null));

    component.ngOnInit();

    expect(actionMeasuresService.Get).toHaveBeenCalledWith(countryCode);
  });
});
