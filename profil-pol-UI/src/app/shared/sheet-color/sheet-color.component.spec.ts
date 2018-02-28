import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SheetColorComponent } from './sheet-color.component';

describe('SheetColorComponent', () => {
  let component: SheetColorComponent;
  let fixture: ComponentFixture<SheetColorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SheetColorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SheetColorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
