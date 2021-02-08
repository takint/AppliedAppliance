import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampusFormsComponent } from './campus-forms.component';

describe('CampusFormsComponent', () => {
  let component: CampusFormsComponent;
  let fixture: ComponentFixture<CampusFormsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CampusFormsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CampusFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
