import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { SchoolFormsComponent } from './school-forms.component';

describe('SchoolFormsComponent', () => {
  let component: SchoolFormsComponent;
  let fixture: ComponentFixture<SchoolFormsComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ SchoolFormsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
