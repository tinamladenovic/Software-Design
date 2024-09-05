import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/env/environment';
import { Observable } from 'rxjs';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { RequestToJoinClub } from './request-to-join-club.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class RequestToJoinClubService {

  constructor(private http: HttpClient, private authService : AuthService) { }

  getRequest() : Observable<PagedResults<RequestToJoinClub>> {
    return this.http.get<PagedResults<RequestToJoinClub>>('https://localhost:44333/api/clubrequest/requesttojoinclub');
  }

  getRequestById(id : number) : Observable<RequestToJoinClub>{
    return this.http.get<RequestToJoinClub>('https://localhost:44333/api/clubrequest/requesttojoinclub/' + id);
  }

  addRequest(request: RequestToJoinClub ): Observable<RequestToJoinClub> {
    return this.http.post<RequestToJoinClub>('https://localhost:44333/api/clubrequest/requesttojoinclub/'+this.authService.user$.getValue().id,request);
  }

  deleteRequest(id: number): Observable<RequestToJoinClub> {
    return this.http.delete<RequestToJoinClub>('https://localhost:44333/api/clubrequest/requesttojoinclub/' + id);
  }

  updateRequest(request: RequestToJoinClub): Observable<RequestToJoinClub> {
    return this.http.put<RequestToJoinClub>('https://localhost:44333/api/clubrequest/requesttojoinclub/'+request.id,request);
  }


}
