import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StartPageInformerComponent } from './start-page-informer.component';

describe('StartPageInformerComponent', () => {
  let component: StartPageInformerComponent;
  let fixture: ComponentFixture<StartPageInformerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StartPageInformerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StartPageInformerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
