// tour-progress.service.ts

import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Review } from './model/tour-rating.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TourProgressService {
  private completionPercentageSubject: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  public completionPercentage$: Observable<number> = this.completionPercentageSubject.asObservable();

  constructor(private http: HttpClient) {}

  public updateCompletionPercentage(percentage: number): void {
    this.completionPercentageSubject.next(percentage);
  }

  public incrementCompletionPercentageBy25(): void {
    const currentPercentage = this.completionPercentageSubject.value;
    const newPercentage = Math.min(currentPercentage + 25, 100);
    this.updateCompletionPercentage(newPercentage);
  }

  
  public completeTour(): void {
    this.updateCompletionPercentage(100);
  }

  addReview(newReview: Review): Observable<Review> {
    return this.http.post<Review>(`https://localhost:44333/api/tourist/tourRating`, newReview);
  }

  
}
