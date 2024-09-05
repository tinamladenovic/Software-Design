import { ObserversModule } from '@angular/cdk/observers';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Report } from '../administration/model/issue-reports.model'
import { environment } from 'src/env/environment';
import { Observable, switchMap, timer } from 'rxjs';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { LatLng } from 'leaflet';
import { Coordinate } from './model/coordinate';
import { TourExecution } from './model/tour-execution';
import { TourRating } from './model/tour-rating.model';
import { CountryCode } from './model/country-code.model';
import { EmergencyNumbers } from './model/emergency-numbers.model';
import { Tour } from '../tour-authoring/model/tour.model';


@Injectable({
  providedIn: 'root'
})
export class TourExecutionService {


  constructor(private http: HttpClient) { }




  getTourRating(): Observable<PagedResults<TourRating>> {


    return this.http.get<PagedResults<TourRating>>('https://localhost:44333/api/tourist/tourRating');
  }


  addReport(report: Report): Observable<Report> {
    return this.http.post<Report>(environment.apiHost + 'tourism/report', report)
  }
  updateProgress(id: number, checkpointId: number, currentPosition: Coordinate, distance: number): Observable<TourExecution> {
    console.log('service, distance covered: ' + distance.toPrecision(2));
    const body = {
      coordinate: currentPosition,
      coveredDistance: distance
    }
    return this.http.patch<TourExecution>(`${environment.apiHost}tourist/execution/tourExecution/${id}/${checkpointId}`, body);
  }
  createTourExecution(tourId: number): Observable<TourExecution> {
    return this.http.post<TourExecution>(environment.apiHost + 'tourist/execution/tourExecution', tourId);
  }


  createTourExecutionForCompositeTour(tourId: number): Observable<TourExecution> {
    return this.http.post<TourExecution>(environment.apiHost + 'tourist/execution/tourExecution/compositetour', tourId);
  }


  abandonTourExecution(id: number): Observable<TourExecution> {
    return this.http.patch<TourExecution>(environment.apiHost + 'tourist/execution/tourExecution/abandon', id);
  }


  getCountryCode(country: string): Observable<CountryCode[]> {
    return this.http.get<CountryCode[]>("https://restcountries.com/v3.1/name/" + country);
  }


  getEmergencyNumbers(code: string): Observable<EmergencyNumbers> {
    const params = new HttpParams().set('code', code);
    return this.http.get<EmergencyNumbers>(environment.apiHost + "emergencynumbers/numbers", { params });
  }


  getRecommendedTours(tourId: number, userId: number): Observable<Tour> {
    const url = `${environment.apiHost}tourist/execution/tourExecution/GetRecomendedForTourAndUser/${tourId}/${userId}`;
    return this.http.get<Tour>(url);
  }
}
