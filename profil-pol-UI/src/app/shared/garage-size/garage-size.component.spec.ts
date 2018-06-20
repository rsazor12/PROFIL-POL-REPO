import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageSizeComponent } from './garage-size.component';

describe('GarageSizeComponent', () => {
  let component: GarageSizeComponent;
  let fixture: ComponentFixture<GarageSizeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GarageSizeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GarageSizeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
