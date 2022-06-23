import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieCreationFormComponent } from './movie-creation-form.component';

describe('MovieCreationFormComponent', () => {
  let component: MovieCreationFormComponent;
  let fixture: ComponentFixture<MovieCreationFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieCreationFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovieCreationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
