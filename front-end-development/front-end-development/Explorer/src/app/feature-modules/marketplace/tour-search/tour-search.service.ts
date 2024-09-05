import { Injectable } from '@angular/core';
import { TourSearch } from '../model/tour-search.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Tour } from '../../tour-authoring/model/tour.model';

@Injectable({
  providedIn: 'root'
})
export class TourSearchService {

  constructor(private http: HttpClient) { }

  getTourSearch(tourSearch: TourSearch): Observable<PagedResults<Tour>> {
    const params = new HttpParams()
        .set('Longitude', tourSearch.longitude.toString())
        .set('Latitude', tourSearch.latitude.toString())
        .set('Range', tourSearch.range.toString());

    return this.http.get<PagedResults<Tour>>('https://localhost:44333/api/tourist/tourSearch', { params });
}
}
