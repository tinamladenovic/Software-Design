import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/env/environment';

@Injectable({
  providedIn: 'root'
})
export class TourStatisticsService {

  constructor(private http: HttpClient) { }

  getTourOrderCount(tourId: number): Observable<number> {
    return this.http.get<number>(
      environment.apiHost + 'tourist/shoppingCart/tourStatistics/orderCount/' + tourId
    );
  }

  getTourRatingCountForPastWeek(tourId: number): Observable<number> {
    return this.http.get<number>(
      environment.apiHost + 'tourist/shoppingCart/tourStatistics/ratingCount/' + tourId
    );
  }

  getTourAverageRatingForPastWeek(tourId: number): Observable<number> {
    return this.http.get<number>(
      environment.apiHost + 'tourist/shoppingCart/tourStatistics/averageRating/' + tourId
    );
  }
}
