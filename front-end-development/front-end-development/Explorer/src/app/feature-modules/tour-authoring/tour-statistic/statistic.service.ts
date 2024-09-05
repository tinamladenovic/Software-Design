import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SingleTourStatistic } from './model/single-tour-statistic.model';
import { environment } from 'src/env/environment';

@Injectable({
  providedIn: 'root'
})
export class StatisticService{

  constructor( private http : HttpClient) {}

  getStatisticForTour(tourId: number): Observable<SingleTourStatistic> {
    const params = new HttpParams().set('tourId', tourId);
    return this.http.get<SingleTourStatistic>(environment.apiHost + 'tourstatistic/singletourstatistic', { params });
  }
}
