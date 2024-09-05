import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TourDataService {
  private tourId: number = 0;

  setTourId(id: number) {
    this.tourId = id;
  }

  getTourId() {
    return this.tourId;
  }
}