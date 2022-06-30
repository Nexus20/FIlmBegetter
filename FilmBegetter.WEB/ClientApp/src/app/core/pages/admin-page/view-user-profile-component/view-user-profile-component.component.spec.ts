import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewUserProfileComponentComponent } from './view-user-profile-component.component';

describe('ViewUserProfileComponentComponent', () => {
  let component: ViewUserProfileComponentComponent;
  let fixture: ComponentFixture<ViewUserProfileComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewUserProfileComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewUserProfileComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
