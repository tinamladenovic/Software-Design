import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthService } from "src/app/infrastructure/auth/auth.service";
import { ClubGuests } from "./clubguests.model";
import { Observable } from "rxjs";



@Injectable({
    providedIn: 'root'
  })
  export class UserService {
    constructor(private http: HttpClient, private authService : AuthService) { }

    getClubGuests(clubId:number,logedInId:number) : Observable<ClubGuests[]> {
        return this.http.get<ClubGuests[]>('https://localhost:44333/api/users/allUsers/ClubMembers/'+clubId+'/'+logedInId);
      }
    getNonClubGuests(clubId:number,logedInId:number) : Observable<ClubGuests[]> {
      return this.http.get<ClubGuests[]>('https://localhost:44333/api/users/allUsers/NonClubMembers/'+clubId+'/'+logedInId);
    }
  }