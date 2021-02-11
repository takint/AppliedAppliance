import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolDocumentListComponent } from './school-document-list.component';

describe('SchoolDocumentListComponent', () => {
  let component: SchoolDocumentListComponent;
  let fixture: ComponentFixture<SchoolDocumentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SchoolDocumentListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolDocumentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
