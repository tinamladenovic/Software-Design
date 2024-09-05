import { TestBed } from '@angular/core/testing';

import { TourExecutionStatsService } from './tour-execution-stats.service';

describe('TourExecutionStatsService', () => {
  let service: TourExecutionStatsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TourExecutionStatsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
