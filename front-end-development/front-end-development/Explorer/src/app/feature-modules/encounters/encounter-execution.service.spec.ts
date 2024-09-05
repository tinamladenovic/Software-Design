import { TestBed } from '@angular/core/testing';

import { EncounterExecutionService } from './encounter-execution.service';

describe('EncounterExecutionService', () => {
  let service: EncounterExecutionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EncounterExecutionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
