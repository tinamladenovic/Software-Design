import { TestBed } from '@angular/core/testing';

import { TourSearchService } from './tour-search.service';

describe('TourSearchService', () => {
  let service: TourSearchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TourSearchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
