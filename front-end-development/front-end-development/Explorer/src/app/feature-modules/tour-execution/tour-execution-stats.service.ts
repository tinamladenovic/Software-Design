import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { environment } from 'src/env/environment';
import { TouristCompletedTours } from './model/tourist-completed-tours';
import { TouristCoveredDistance } from './model/tourist-covered-distance';

@Injectable({
  providedIn: 'root'
})
export class TourExecutionStatsService {

  constructor(private http: HttpClient) { }

  getCompletedToursCount(): Observable<number> {
    return this.http.get<number>(
      environment.apiHost + 'tourist/execution/tourExecutionStats/totalCount'
    );
  }

  getTotalCoveredDistance(): Observable<number> {
    return this.http.get<number>(
      environment.apiHost + 'tourist/execution/tourExecutionStats/totalDistance'
    );
  }

  getTouristCompletedToursCount(): Observable<number> {
    return this.http.get<number>(
      environment.apiHost + 'tourist/execution/tourExecutionStats/touristCount'
    );
  }

  getTouristCoveredDistance(): Observable<number> {
    return this.http.get<number>(
      environment.apiHost + 'tourist/execution/tourExecutionStats/touristDistance'
    );
  }

  getTouristsRankedByCompletedToursCurrentMonth(): Observable<PagedResults<TouristCompletedTours>> {
    return this.http.get<PagedResults<TouristCompletedTours>>(
      environment.apiHost + 'tourist/leaderboards/tourExecution/currentMonth/completedTours'
    );
  }

  getTouristsRankedByCompletedToursCurrentWeek(): Observable<PagedResults<TouristCompletedTours>> {
    return this.http.get<PagedResults<TouristCompletedTours>>(
      environment.apiHost + 'tourist/leaderboards/tourExecution/currentWeek/completedTours'
    );
  }

  getTouristsRankedByCoveredDistanceCurrentMonth(): Observable<PagedResults<TouristCoveredDistance>> {
    return this.http.get<PagedResults<TouristCoveredDistance>>(
      environment.apiHost + 'tourist/leaderboards/tourExecution/currentMonth/coveredDistance'
    );
  }

  getTouristsRankedByCoveredDistanceCurrentWeek(): Observable<PagedResults<TouristCoveredDistance>> {
    return this.http.get<PagedResults<TouristCoveredDistance>>(
      environment.apiHost + 'tourist/leaderboards/tourExecution/currentWeek/coveredDistance'
    );
  }

}
