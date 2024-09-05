import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ClubRequest } from "./club-request.model";
import { Observable } from "rxjs";


@Injectable({
    providedIn: 'root'
  })

  export class ClubRequestService {

    constructor(private http: HttpClient) { }

    sendRequest(clubRequest : ClubRequest) : Observable<ClubRequest>{
        return this.http.post<ClubRequest>('https://localhost:44333/api/sendinvite/clubrequest',clubRequest); 
      }

  }