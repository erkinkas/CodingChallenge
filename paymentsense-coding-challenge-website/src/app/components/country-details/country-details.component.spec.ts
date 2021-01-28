import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Component, Input } from '@angular/core';

import { Observable, BehaviorSubject } from 'rxjs';

import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, convertToParamMap } from '@angular/router';

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
    return new BehaviorSubject<CountryDetailsModel>(null).asObservable();
  }
}

describe('CountryDetailsComponent', () => {
  let component: CountryDetailsComponent;
  let fixture: ComponentFixture<CountryDetailsComponent>;

  let countryCode: 'country code';

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
        RouterTestingModule
      ],
      providers: [
        { provide: CountryDetailsService, useClass: MockCountryDetailsService },
        {
          provide: ActivatedRoute, useValue: {
            snapshot: {
              paramMap: convertToParamMap({ 'code': countryCode })
            }
          }
        }
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
      .and.returnValue(new BehaviorSubject<CountryDetailsModel>(model).asObservable());

    component.ngOnInit();

    expect(component.country).toBe(model);
  });

  it('should call service with code from route', () => {
    const actionMeasuresService = TestBed.get(CountryDetailsService) as CountryDetailsService;
    spyOn(actionMeasuresService, 'Get')
      .and.returnValue(new BehaviorSubject<CountryDetailsModel>(null).asObservable());

    component.ngOnInit();

    expect(actionMeasuresService.Get).toHaveBeenCalledWith(countryCode);
  });
});
