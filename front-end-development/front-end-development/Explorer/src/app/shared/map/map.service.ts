import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LatLng } from './latLng.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MapService {

  constructor(private http: HttpClient) {}

  search(street: string): Observable<any> {
    return this.http.get(
      'https://nominatim.openstreetmap.org/search?format=json&q=' + street
    );
  }

  reverseSearch(lat: number, lon: number): Observable<any> {
    return this.http.get(
      `https://nominatim.openstreetmap.org/reverse?format=json&lat=${lat}&lon=${lon}&<params>`
    );
  }
  //Prosledjujemo niz duzine i sirine - [ {lat: 10, lng: 10}, {lat: 44.4 , lng: 24.1} ]
  getElevation(latLngs: LatLng[]): Observable<any> {
    const result = latLngs.map( (latLng:LatLng) => {
      return `${latLng.lat},${latLng.lng}`;
    }).join('|');
    return this.http.get(`https://api.open-elevation.com/api/v1/lookup?locations=${result}`)
}

}
