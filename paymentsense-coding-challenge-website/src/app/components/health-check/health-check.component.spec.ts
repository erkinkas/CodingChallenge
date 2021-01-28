import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Observable, BehaviorSubject } from 'rxjs';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faThumbsUp, faThumbsDown } from '@fortawesome/free-regular-svg-icons';

import { ApiHealthCheckService } from '../../services';

import { HealthCheckComponent } from './health-check.component';

class MockApiHealthCheckService {
  isActiveSource = new BehaviorSubject<boolean>(null);
  isActive$: Observable<boolean> = this.isActiveSource.asObservable();
}

describe('HealthCheckComponent', () => {
  let component: HealthCheckComponent;
  let fixture: ComponentFixture<HealthCheckComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        FontAwesomeModule
      ],
      declarations: [
        HealthCheckComponent
      ],
      providers: [
        { provide: ApiHealthCheckService, useClass: MockApiHealthCheckService }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthCheckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  [
    { apiHealth: true, expectedIcon: faThumbsUp, expectedIconColour: 'green' },
    { apiHealth: false, expectedIcon: faThumbsDown, expectedIconColour: 'red' }
  ].forEach((dataSet) => {
    it('should have icon as "' + dataSet.expectedIcon.iconName + '" and icon colour as "' + dataSet.expectedIconColour + '"', () => {
      const apiHealthCheckService = TestBed.get(ApiHealthCheckService) as ApiHealthCheckService;
      apiHealthCheckService.isActive$ = new BehaviorSubject<boolean>(dataSet.apiHealth).asObservable();

      component.ngOnInit();

      expect(component.apiActiveIcon).toBe(dataSet.expectedIcon);
      expect(component.apiActiveIconColour).toBe(dataSet.expectedIconColour);
    });
  });
});
