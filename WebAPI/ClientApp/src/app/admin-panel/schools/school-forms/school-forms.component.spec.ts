import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolFormsComponent } from './school-forms.component';

describe('SchoolFormsComponent', () => {
  let component: SchoolFormsComponent;
  let fixture: ComponentFixture<SchoolFormsComponent>;

  beforeEach(async(() => {
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
