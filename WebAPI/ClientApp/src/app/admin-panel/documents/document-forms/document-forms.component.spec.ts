import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocumentFormsComponent } from './document-forms.component';

describe('DocumentFormsComponent', () => {
  let component: DocumentFormsComponent;
  let fixture: ComponentFixture<DocumentFormsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DocumentFormsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DocumentFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
