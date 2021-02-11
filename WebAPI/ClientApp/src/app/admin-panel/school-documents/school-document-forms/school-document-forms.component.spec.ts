import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolDocumentFormsComponent } from './school-document-forms.component';

describe('SchoolDocumentFormsComponent', () => {
  let component: SchoolDocumentFormsComponent;
  let fixture: ComponentFixture<SchoolDocumentFormsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchoolDocumentFormsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolDocumentFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
