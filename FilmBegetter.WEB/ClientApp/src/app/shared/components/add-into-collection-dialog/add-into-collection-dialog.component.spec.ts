import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddIntoCollectionDialogComponent } from './add-into-collection-dialog.component';

describe('AddIntoCollectionDialogComponent', () => {
  let component: AddIntoCollectionDialogComponent;
  let fixture: ComponentFixture<AddIntoCollectionDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddIntoCollectionDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddIntoCollectionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
