import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieUpdatingFormComponent } from './movie-updating-form.component';

describe('MovieUpdatingFormComponent', () => {
  let component: MovieUpdatingFormComponent;
  let fixture: ComponentFixture<MovieUpdatingFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieUpdatingFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovieUpdatingFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
