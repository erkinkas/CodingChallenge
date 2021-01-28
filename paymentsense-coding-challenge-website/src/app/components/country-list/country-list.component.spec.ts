import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Component, Input } from '@angular/core';

import { By } from '@angular/platform-browser';

import { Observable, of } from 'rxjs';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../../material.module';

import { PagedResponse, CountryListItemModel } from '../../models';

import { CountryListService } from '../../services';

import { CountryListComponent } from './country-list.component';

@Component({ selector: 'app-country-list-item-card', template: '' })
class MockCountryListItemCardComponent {
  @Input() country: CountryListItemModel
}

class MockCountryListService {
  public Get(pageIndex: number, pageSize: number): Observable<PagedResponse<CountryListItemModel>> {
    return of(null);
  }
}

describe('CountryListComponent', () => {
  let component: CountryListComponent;
  let fixture: ComponentFixture<CountryListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        MockCountryListItemCardComponent,
        CountryListComponent
      ],
      imports: [
        MaterialModule,
        BrowserAnimationsModule
      ],
      providers: [
        { provide: CountryListService, useClass: MockCountryListService },
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should not render', () => {
    const model = <PagedResponse<CountryListItemModel>>{
      items: null
    };

    const countryListService = TestBed.get(CountryListService) as CountryListService;
    spyOn(countryListService, 'Get')
      .and.returnValue(of(model));

    component.ngOnInit();

    fixture.detectChanges();
    const compiled = fixture.debugElement;

    let element = compiled.query(By.css('.view-list-item'));
    expect(element).toBeNull();
  });

  it('should render items N times', () => {
    const itemsCount: number = 2;

    let items: Array<CountryListItemModel> = [];
    for (var index = 0; index < itemsCount; index++) {
      const item = new CountryListItemModel();
      items.push(item);
    }

    const model = <PagedResponse<CountryListItemModel>>{
      items: items
    };

    const countryListService = TestBed.get(CountryListService) as CountryListService;
    spyOn(countryListService, 'Get')
      .and.returnValue(of(model));

    component.ngOnInit();

    fixture.detectChanges();

    const compiled = fixture.debugElement;

    const dataElement = compiled.query(By.css('.view-list'));
    expect(dataElement).not.toBeNull();

    const elements = compiled.queryAll(By.css('.view-list-item'));
    expect(elements).not.toBeNull();
    expect(elements.length).toBe(itemsCount);
  });
});
