import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgramCategoryFormsComponent } from './program-category-forms.component';

describe('ProgramCategoryFormsComponent', () => {
  let component: ProgramCategoryFormsComponent;
  let fixture: ComponentFixture<ProgramCategoryFormsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProgramCategoryFormsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgramCategoryFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
