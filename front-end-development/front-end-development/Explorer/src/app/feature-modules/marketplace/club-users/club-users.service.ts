import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ClubUsers } from './club-users.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClubUsersService {

  constructor(private http: HttpClient) { }

    addUserToClub(clubUser : ClubUsers) : Observable<ClubUsers>{
      return this.http.post<ClubUsers>('https://localhost:44333/api/club/clubUsers',clubUser); 
    }

    deleteUserFromClub(clubId: number,userId: number): Observable<ClubUsers>{
      return this.http.delete<ClubUsers>('https://localhost:44333/api/club/clubUsers/' + clubId + '/' + userId);
    }

}
