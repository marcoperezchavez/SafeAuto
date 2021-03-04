import { TestBed } from '@angular/core/testing';

import { SafeAutoService } from './safe-auto.service';

describe('SafeAutoService', () => {
  let service: SafeAutoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SafeAutoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
