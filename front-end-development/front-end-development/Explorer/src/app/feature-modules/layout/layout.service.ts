import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  AnswerDate,
  Questionnaire,
  UserProfile,
} from './model/userProfile.model';

@Injectable({
  providedIn: 'root',
})
export class LayoutService {
  constructor(private http: HttpClient) {}

  getProfile(id: number): Observable<UserProfile> {
    return this.http.get<UserProfile>(
      `https://localhost:44333/api/person/${id}`
    );
  }

  updateProfile(
    profile: UserProfile,
    imageFile: File
  ): Observable<UserProfile> {
    const formData = new FormData();
    console.log(profile);
    console.log(imageFile);

    formData.append('id', profile.id.toString());
    formData.append('userId', profile.userId.toString());
    formData.append('name', profile.name);
    formData.append('surname', profile.surname);
    formData.append('email', profile.email);
    formData.append('motto', profile.motto);
    formData.append('biography', profile.biography);
    formData.append('Image', 'NekiString');
    formData.append('Image', imageFile, imageFile.name);

    console.log(formData);

    return this.http.put<UserProfile>(
      'https://localhost:44333/api/person/',
      formData
    );
  }

  getQuestion(): Observable<Questionnaire> {
    return this.http.get<Questionnaire>(
      'https://localhost:44333/api/questionnaire/getQuestion'
    );
  }

  newAnswerDate(userId: number): Observable<AnswerDate> {
    return this.http.post<AnswerDate>(
      `https://localhost:44333/api/questionnaire/createOrUpdateLastAnswerDate/${userId}`,
      null
    );
  }

  getLastAnswerDate(userId: number | undefined): Observable<AnswerDate> {
    return this.http.get<AnswerDate>(
      `https://localhost:44333/api/questionnaire/getLastAnswerDate/${userId}`
    );
  }
}
