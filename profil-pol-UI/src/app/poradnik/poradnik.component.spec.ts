import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PoradnikComponent } from './poradnik.component';

describe('PoradnikComponent', () => {
  let component: PoradnikComponent;
  let fixture: ComponentFixture<PoradnikComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PoradnikComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PoradnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
