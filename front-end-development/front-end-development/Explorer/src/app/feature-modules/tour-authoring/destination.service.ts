import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Destination } from './model/destination.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { environment } from 'src/env/environment';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class DestinationService {

  constructor(
    private http: HttpClient,
    private toastr: ToastrService
    ) { }

  getDestinations(): Observable<PagedResults<Destination>> {
    return this.http.get<PagedResults<Destination>>(
      environment.apiHost + 'author/destination'
    );
  }
  addDestination(destination: Destination): Observable<Destination> {
    return this.http.post<Destination>(
      environment.apiHost + 'author/destination',
      destination
    );
  }

  deleteDestination(id: number): Observable<Destination> {
    return this.http.delete<Destination>(
      environment.apiHost + 'author/destination/' + id
    );
  }
  updateDestination(destination: Destination): Observable<Destination> {
    return this.http.put<Destination>(
      environment.apiHost + 'author/destination',
      destination
    );
  }

  showDestinationCreated(): void {
    this.toastr.success('Destination successfully created.', 'Destination created');
  }

  showDestinationEdited(): void {
    this.toastr.success('Destination successfully edited.', 'Destination edited');
  }

  showDestinationDeleted(): void {
    this.toastr.success('Destination successfully deleted.', 'Destination deleted');
  }
}
