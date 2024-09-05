import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/env/environment';
import { TextWrapper } from './model/text-wrapper.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(private http: HttpClient) { }

  getFullImageUrl(imageURL: string): string {
    return environment.apiHost + `image/${imageURL}`;
  }

  uploadImage(fileData: FormData): Observable<TextWrapper> {
    return this.http.post<TextWrapper>(environment.apiHost + 'image', fileData);
  }
}
