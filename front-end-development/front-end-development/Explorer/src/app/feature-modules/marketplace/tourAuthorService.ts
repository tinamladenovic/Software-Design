import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TourAuthorService {
  private authorId: number = 0;

  setAuthorId(id: number) {
    this.authorId = id;
  }

  getAuthorId() : number{
    return this.authorId;
  }
}