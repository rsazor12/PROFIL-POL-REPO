import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageCustomComponent } from './garage-custom.component';

describe('GarageCustomComponent', () => {
  let component: GarageCustomComponent;
  let fixture: ComponentFixture<GarageCustomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GarageCustomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GarageCustomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
