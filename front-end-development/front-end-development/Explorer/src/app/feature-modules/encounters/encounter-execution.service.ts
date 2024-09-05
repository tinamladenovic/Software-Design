import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EncounterExecution } from './model/encounter-execution.model';
import { Coordinate } from '../tour-execution/model/coordinate';
import { environment } from 'src/env/environment';
import { PagedResults } from "src/app/shared/model/paged-results.model";
import { Observable } from 'rxjs';
import { EncounterStatistics } from './model/encounters.model';

@Injectable({
  providedIn: 'root'
})
export class EncounterExecutionService {

  constructor(private http: HttpClient) { }

  activate(encounterId: number, coordinate: Coordinate): Observable<EncounterExecution> {
    return this.http.post<EncounterExecution>(
      environment.apiHost + 'tourist/execution/encounter/' + encounterId, coordinate);
  }

  abandon(executionId: number): Observable<EncounterExecution> {
    return this.http.patch<EncounterExecution>(
      environment.apiHost + 'tourist/execution/encounter/abandon', executionId);
  }

  checkIfCompleted(executionId: number, coordinate: Coordinate): Observable<EncounterExecution> {
    return this.http.patch<EncounterExecution>(
      environment.apiHost + 'tourist/execution/encounter/' + executionId, coordinate);
  }

  completeMiscEncounter(executionId: number): Observable<EncounterExecution> {
    return this.http.patch<EncounterExecution>(
      environment.apiHost + 'tourist/execution/encounter/completeMiscEncounter', executionId);
  }
  
  getEncounterStatsForTourist(touristId: number): Observable<EncounterStatistics> {
    return this.http.get<EncounterStatistics>(
        environment.apiHost + `tourist/execution/encounter/statistics/user/${touristId}`);
  }

}
