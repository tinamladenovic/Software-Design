import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Checkpoint } from '../tour-authoring/model/checkpoint.model';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { Observable } from 'rxjs';
import { environment } from 'src/env/environment';

@Injectable({
  providedIn: 'root'
})
export class TouristCheckpointService {

  constructor(private http: HttpClient) { }

  getCheckpoints(): Observable<PagedResults<Checkpoint>> {
    return this.http.get<PagedResults<Checkpoint>>('https://localhost:44333/api/tour/tourist/checkpoints')
  }


  addCheckpoints(tourId:number, checkpoints: Checkpoint[]): void {
    let checkpointsid: number[] = checkpoints.map(checkpoint => checkpoint.id!);
    this.http.post<void>('https://localhost:44333/api/tour/'+ tourId + '/checkpoints' , checkpointsid).subscribe();
  }

}
