import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllShowsComponent } from './all-shows.component';

describe('AllShowsComponent', () => {
  let component: AllShowsComponent;
  let fixture: ComponentFixture<AllShowsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllShowsComponent]
    });
    fixture = TestBed.createComponent(AllShowsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
