import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';

import { Router } from '@angular/router';

import { MaterialModule } from '../../material.module';

import { CountryListItemModel } from '../../models';

import { CountryListItemCardComponent } from './country-list-item-card.component';

describe('CountryListItemCardComponent', () => {
  let component: CountryListItemCardComponent;
  let fixture: ComponentFixture<CountryListItemCardComponent>;

  let routerSpy = {
    navigate: jasmine.createSpy('navigate')
  }

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        CountryListItemCardComponent
      ],
      imports: [
        MaterialModule
      ],
      providers: [
        { provide: Router, useValue: routerSpy }
      ]
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

  it('should not render', () => {
    component.country = null;

    fixture.detectChanges();
    const compiled = fixture.debugElement;

    let element = compiled.query(By.css('.card'));
    expect(element).toBeNull();
  });

  it('should render', () => {
    const model: CountryListItemModel = <CountryListItemModel>{
      alpha3Code: `country alpha3Code`,
      flag: `country link to flag`,
      name: `country name`,
      region: `country region`,
    }
    component.country = model;

    fixture.detectChanges();

    const element = fixture.debugElement.query(By.css('.card'));
    expect(element).not.toBeNull();

    expect(element.nativeElement.textContent).toContain(model.name);
    expect(element.nativeElement.textContent).toContain(model.region);
  });

  it('should redirect on click', async(() => {
    const model: CountryListItemModel = <CountryListItemModel>{
      alpha3Code: `country alpha3Code`,
      flag: `country link to flag`,
      name: `country name`,
      region: `country region`,
    }
    component.country = model;

    fixture.detectChanges();
    let element = fixture.debugElement.query(By.css('.card'));
    expect(element).not.toBeNull();

    element.triggerEventHandler('click', null);
    fixture.detectChanges();

    fixture.whenStable().then(() => {
      expect(routerSpy.navigate).toHaveBeenCalledWith([`details/${model.alpha3Code}`]);
    });
  }));
});
