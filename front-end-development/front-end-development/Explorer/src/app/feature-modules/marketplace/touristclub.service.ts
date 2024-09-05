import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedResults } from 'src/app/shared/model/paged-results.model';
import { TouristClub } from './model/touristclub.model';
import { AuthService } from 'src/app/infrastructure/auth/auth.service';


@Injectable({
  providedIn: 'root'
})
export class TouristclubService {

  constructor(private http: HttpClient, private authService : AuthService) { }

  getTouristClubs() : Observable<PagedResults<TouristClub>> {
    return this.http.get<PagedResults<TouristClub>>('https://localhost:44333/api/club/touristclub');
  }

  createTouristClub(touristClub: TouristClub, imageFile: File): Observable<TouristClub> {
    // Create a FormData object to send a multipart/form-data request
    const formData = new FormData();
    
    // Append the image file to the form data
    formData.append('imageFile', imageFile, imageFile.name);
    
    // Append the other form data fields
    formData.append('clubName', touristClub.clubName);
    formData.append('description', touristClub.description);
    
    return this.http.post<TouristClub>('https://localhost:44333/api/club/touristclub/' + this.authService.user$.getValue().id, formData);
  }
  
  
  getClubDetails(id : number) : Observable<TouristClub>{
    return this.http.get<TouristClub>('https://localhost:44333/api/club/touristclub/' + id);
  }
  
  updateClubDetails(touristClub : TouristClub) : Observable<TouristClub> {
    return this.http.put<TouristClub>('https://localhost:44333/api/club/touristclub/' + touristClub.id, touristClub);
  }
}
