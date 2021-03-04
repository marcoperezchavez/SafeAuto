import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SafeAutoComponent } from './safe-auto.component';

describe('SafeAutoComponent', () => {
  let component: SafeAutoComponent;
  let fixture: ComponentFixture<SafeAutoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SafeAutoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SafeAutoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
