import { TestBed } from '@angular/core/testing';

import { TourStatisticsService } from './tour-statistics.service';

describe('TourStatisticsService', () => {
  let service: TourStatisticsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TourStatisticsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
