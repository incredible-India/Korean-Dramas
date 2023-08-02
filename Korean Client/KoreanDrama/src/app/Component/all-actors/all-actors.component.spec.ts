import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllActorsComponent } from './all-actors.component';

describe('AllActorsComponent', () => {
  let component: AllActorsComponent;
  let fixture: ComponentFixture<AllActorsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllActorsComponent]
    });
    fixture = TestBed.createComponent(AllActorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
