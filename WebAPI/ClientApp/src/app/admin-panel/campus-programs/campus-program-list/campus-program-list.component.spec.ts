import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampusProgramListComponent } from './campus-program-list.component';

describe('CampusProgramListComponent', () => {
  let component: CampusProgramListComponent;
  let fixture: ComponentFixture<CampusProgramListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CampusProgramListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CampusProgramListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
