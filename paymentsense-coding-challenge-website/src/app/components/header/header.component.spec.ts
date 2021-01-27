import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Component } from '@angular/core';

import { MatToolbarModule } from '@angular/material/toolbar';
// import { MatIconModule } from '@angular/material/icon';

import { HeaderComponent } from './header.component';

@Component({ selector: 'app-health-check', template: '' })
class MockHealthCheckComponent {
}

describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        MockHealthCheckComponent,

        HeaderComponent
      ],
      imports: [
        MatToolbarModule,
        // MatIconModule
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it(`should have as title 'Paymentsense Coding Challenge'`, () => {
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('Paymentsense Coding Challenge!');
  });

  it('should render title with id "title"', () => {
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('#title').textContent).toContain('Paymentsense Coding Challenge!');
  });
});