import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridEditFormComponent } from './grid-edit-form.component';

describe('GridEditFormComponent', () => {
  let component: GridEditFormComponent;
  let fixture: ComponentFixture<GridEditFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridEditFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
