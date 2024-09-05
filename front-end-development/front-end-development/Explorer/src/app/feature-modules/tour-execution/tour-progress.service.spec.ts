import { TestBed } from '@angular/core/testing';

import { TourProgressService } from './tour-progress.service';

describe('TourProgressService', () => {
  let service: TourProgressService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TourProgressService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
