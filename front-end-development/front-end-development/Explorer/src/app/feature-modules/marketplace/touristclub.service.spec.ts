import { TestBed } from '@angular/core/testing';

import { TouristclubService } from './touristclub.service';

describe('TouristclubService', () => {
  let service: TouristclubService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TouristclubService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
