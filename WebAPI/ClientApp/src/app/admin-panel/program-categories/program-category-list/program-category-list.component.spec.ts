import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgramCategoryListComponent } from './program-category-list.component';

describe('ProgramCategoryListComponent', () => {
  let component: ProgramCategoryListComponent;
  let fixture: ComponentFixture<ProgramCategoryListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProgramCategoryListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgramCategoryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
