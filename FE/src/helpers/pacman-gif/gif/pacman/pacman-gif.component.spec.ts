import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PacmanGifComponent } from './pacman-gif.component';

describe('PacmanGifComponent', () => {
  let component: PacmanGifComponent;
  let fixture: ComponentFixture<PacmanGifComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PacmanGifComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PacmanGifComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
