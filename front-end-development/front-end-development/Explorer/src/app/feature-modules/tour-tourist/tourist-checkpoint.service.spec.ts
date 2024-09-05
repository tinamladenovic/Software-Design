import { TestBed } from '@angular/core/testing';

import { TouristCheckpointService } from './tourist-checkpoint.service';

describe('TouristCheckpointService', () => {
  let service: TouristCheckpointService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TouristCheckpointService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
