import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditUserRolesComponentComponent } from './edit-user-roles-component.component';

describe('EditUserRolesComponentComponent', () => {
  let component: EditUserRolesComponentComponent;
  let fixture: ComponentFixture<EditUserRolesComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditUserRolesComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditUserRolesComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
